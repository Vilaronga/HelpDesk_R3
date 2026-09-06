using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Implementação do serviço de chamado, responsável por gerenciar operações relacionadas a chamados no sistema de Help Desk.
    /// </summary>
    public class ChamadoService : IChamadoService
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Inicializa uma nova instância do serviço de cliente com o contexto do banco de dados.
        /// </summary>
        /// <param name="appDbContext">O contexto do banco de dados.</param>
        public ChamadoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Adiciona um novo chamado ao sistema de Help Desk.
        /// </summary>
        /// <param name="chamadoRequestDTO">O DTO contendo os dados do chamado a ser adicionado.</param>
        /// <returns>O DTO com os dados do chamado aberto.</returns>
        public async Task<ChamadoResponseDTO> AddChamadoAsync(ChamadoRequestDTO chamadoRequestDTO)
        {

            var novoChamado = new Chamado 
            {
                IdCliente = chamadoRequestDTO.IdCliente,
                IdEmpresa = chamadoRequestDTO.IdEmpresa,
                IdProduto = chamadoRequestDTO.IdProduto,
                Titulo = chamadoRequestDTO.Titulo,
                Descricao = chamadoRequestDTO.Descricao,
                Prioridade = chamadoRequestDTO.Prioridade,
                Categoria = chamadoRequestDTO.Categoria
                //TODO: IdColaborador - automático
            };

            //Definições automáticas
            novoChamado.DataAbertura = DateTime.UtcNow;
            novoChamado.DataAtualizacao = DateTime.UtcNow;
            novoChamado.Status = StatusEnum.Aberto;

            // Busca regra SLA para aquele conjunto de informações
            var regraSla = await BuscarRegraSlaAsync(novoChamado.IdProduto, novoChamado.Categoria, novoChamado.Prioridade);
            if (regraSla != null)
            {
                novoChamado.SlaPrazo = novoChamado.DataAbertura.Add(regraSla.TempoResolucao);
            }

            _appDbContext.Chamado.Add(novoChamado);
            await _appDbContext.SaveChangesAsync();

            // Busca no banco pelo ID para adquirir os nomes que retornarão no DTO
            var Cliente = await _appDbContext.Cliente.FindAsync(novoChamado.IdCliente);
            var Empresa = await _appDbContext.Empresa.FindAsync(novoChamado.IdEmpresa);
            var Produto = await _appDbContext.Produto.FindAsync(novoChamado.IdProduto);

            var ChamadoCriado = new ChamadoResponseDTO
            {
              CodigoPublico = novoChamado.CodigoPublico,
              Titulo = novoChamado.Titulo,
              Descricao = novoChamado.Descricao,
              Status = novoChamado.Status.ToString(),
              Prioridade = novoChamado.Prioridade.ToString(),
              Categoria = novoChamado.Categoria.ToString(),
              DataAbertura = novoChamado.DataAbertura,
              DataAtualizacao = novoChamado.DataAtualizacao,
              SlaPrazo = novoChamado.SlaPrazo,
              NomeCliente = Cliente.Nome,
              NomeEmpresa = Empresa.NomeEmpresa,
              NomeProduto = Produto.NomeProduto
            };

            return ChamadoCriado;
        }

        /// <summary>
        /// Atualiza um chamado ao sistema de Help Desk.
        /// </summary>
        /// <param name="guid">Código Público do chamado a ser atualizado.</param>
        /// <param name="chamadoAtualizado">O DTO contendo os novos dados do chamado a ser atualizado.</param>
        /// <returns>Confirmação se foi ou não atualizado (true ou false).</returns>
        public async Task<bool> UpdateChamadoAsync(Guid guid, ChamadoUpdateDTO chamadoAtualizado)
        {
            var chamadoExistente = await _appDbContext.Chamado.FirstOrDefaultAsync(c => c.CodigoPublico == guid);
            if (chamadoExistente == null) return false;

            if (chamadoExistente.IdProduto != chamadoAtualizado.IdProduto ||
                chamadoExistente.Categoria != chamadoAtualizado.Categoria ||
                chamadoExistente.Prioridade != chamadoAtualizado.Prioridade)
            {
                var regraSla = await BuscarRegraSlaAsync(chamadoAtualizado.IdProduto, chamadoAtualizado.Categoria, chamadoAtualizado.Prioridade);
                chamadoExistente.SlaPrazo = regraSla != null 
                    ? chamadoExistente.DataAbertura.Add(regraSla.TempoResolucao) 
                    : null;
            }

            // TODO: Implementar aqui a atribuição atuomática ao colaborador responsável pelo chamado
            chamadoExistente.IdColaborador = (chamadoAtualizado.IdColaborador == 0 || chamadoAtualizado.IdColaborador == null) ?  null : chamadoAtualizado.IdColaborador;
            chamadoExistente.Titulo = chamadoAtualizado.Titulo;
            chamadoExistente.Descricao = chamadoAtualizado.Descricao;
            chamadoExistente.Status = chamadoAtualizado.Status;
            chamadoExistente.Categoria = chamadoAtualizado.Categoria;
            chamadoExistente.Prioridade = chamadoAtualizado.Prioridade;
            chamadoExistente.IdProduto = chamadoAtualizado.IdProduto;
            chamadoExistente.DataAtualizacao = DateTime.UtcNow;


            if (chamadoAtualizado.Status == StatusEnum.Fechado && chamadoExistente.DataEncerramento == null)
            {
                chamadoExistente.DataEncerramento = DateTime.UtcNow;
            }

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Busca um chamado no sistema de Help Desk pelo código Público.
        /// </summary>
        /// <param name="guid">Código Público do chamado a ser adicionado.</param>
        /// <returns>O DTO com os dados do chamado aberto.</returns>
        public async Task<ChamadoResponseDTO> GetChamadoByGuidAsync(Guid guid)
        {
            var chamado = await _appDbContext.Chamado.FirstOrDefaultAsync(c => c.CodigoPublico == guid);

            if (chamado == null)
            {
                throw new Exception("Chamado não encontado pelo Guid: " + guid);
            }

            var Cliente = await _appDbContext.Cliente.FindAsync(chamado.IdCliente);
            var Empresa = await _appDbContext.Empresa.FindAsync(chamado.IdEmpresa);
            var Produto = await _appDbContext.Produto.FindAsync(chamado.IdProduto);

            return new ChamadoResponseDTO
            {
                CodigoPublico = chamado.CodigoPublico,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                Status = chamado.Status.ToString(),
                Prioridade = chamado.Prioridade.ToString(),
                Categoria = chamado.Categoria.ToString(),
                DataAbertura = chamado.DataAbertura,
                DataAtualizacao = chamado.DataAtualizacao,
                SlaPrazo = chamado.SlaPrazo,
                NomeCliente = Cliente.Nome,
                NomeEmpresa = Empresa.NomeEmpresa,
                NomeProduto = Produto.NomeProduto
            };
        }  

        private async Task<SlaCategoria?> BuscarRegraSlaAsync(long idProduto, CategoriaEnum categoria, PrioridadeEnum prioridade)
        {
            return await _appDbContext.SlaCategoria
                .FirstOrDefaultAsync(s => s.IdProduto == idProduto 
                                       && s.Categoria == categoria 
                                       && s.Prioridade == prioridade);
        }
    }
}