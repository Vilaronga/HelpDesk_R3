using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Implementação do serviço de SLA, responsável por gerenciar operações relacionadas às Regras SLA no sistema de Help Desk.
    /// </summary>
    public class SlaCategoriaService : ISlaCategoriaService
    {
        
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Inicializa uma nova instância do serviço de cliente com o contexto do banco de dados.
        /// </summary>
        /// <param name="appDbContext">O contexto do banco de dados.</param>
        public SlaCategoriaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Busca todas as Regras SLA no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista de DTO das regras existentes.</returns>
        public async Task<IEnumerable<SlaCategoriaResponseDTO>> GetAllAsync()
        {
            var regras = await _appDbContext.SlaCategoria
                .Include(s => s.Produto)
                .ToListAsync();

            return regras.Select(MapToResponseDTO);
        }

        /// <summary>
        /// Busca uma Regras SLA pelo ID no sistema de Help Desk. Pode ser nulo.
        /// </summary>
        /// <returns>DTO da regra se existente.</returns>
        public async Task<SlaCategoriaResponseDTO?> GetByIdAsync(int id)
        {
            var regra = await _appDbContext.SlaCategoria
                .Include(s => s.Produto)
                .FirstOrDefaultAsync(s => s.Id == id);

            return regra == null ? null : MapToResponseDTO(regra);
        }

        /// <summary>
        /// Adiciona uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="novaRegraDTO">DTO com os dados na nova regra a ser inserida</param>
        /// <returns>DTO da regra criada</returns> 

        public async Task<SlaCategoriaResponseDTO> CreateRuleAsync(SlaCategoriaRequestDTO novaRegraDTO)
        {
            var novaRegra = new SlaCategoria
            {
                IdProduto = novaRegraDTO.IdProduto,
                Categoria = novaRegraDTO.Categoria,
                Prioridade = novaRegraDTO.Prioridade,
                TempoResposta = TimeSpan.FromMinutes(novaRegraDTO.TempoRespostaMinutos),
                TempoResolucao = TimeSpan.FromMinutes(novaRegraDTO.TempoResolucaoMinutos)
            };

            _appDbContext.SlaCategoria.Add(novaRegra);
            await _appDbContext.SaveChangesAsync();

            await _appDbContext.Entry(novaRegra).Reference(s => s.Produto).LoadAsync();

            return MapToResponseDTO(novaRegra);
        }

        /// <summary>
        /// Atualiza uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra que será atualizada</param>
        /// <param name="regraAtualizadaDTO">DTO com os nvos dados da regra</param>
        /// <returns>Confirmação de atualização (true ou false)</returns> 
        public async Task<bool> UpdateRuleAsync(int id, SlaCategoriaRequestDTO regraAtualizadaDTO)
        {
            var regraExistente = await _appDbContext.SlaCategoria.FindAsync(id);
            if (regraExistente == null) return false;

            regraExistente.IdProduto = regraAtualizadaDTO.IdProduto;
            regraExistente.Categoria = regraAtualizadaDTO.Categoria;
            regraExistente.Prioridade = regraAtualizadaDTO.Prioridade;
            regraExistente.TempoResposta = TimeSpan.FromMinutes(regraAtualizadaDTO.TempoRespostaMinutos);
            regraExistente.TempoResolucao = TimeSpan.FromMinutes(regraAtualizadaDTO.TempoResolucaoMinutos);

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Deleta uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra a ser excluída</param>
        /// <returns>Confirmação de exclusão (true ou false)</returns> 
        public async Task<bool> DeleteRuleAsync(int id)
        {
            var regra = await _appDbContext.SlaCategoria.FindAsync(id);
            if (regra == null) return false;

            _appDbContext.SlaCategoria.Remove(regra);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Método auxiliar que converte o objeto em DTO de Resposta
        /// </summary>
        /// <param name="regra">Objeto da regra</param>
        /// <returns>Retorna um SlaCategoriaResponseDTO</returns>
        private static SlaCategoriaResponseDTO MapToResponseDTO(SlaCategoria regra)
        {
            return new SlaCategoriaResponseDTO
            {
                Id = regra.Id,
                IdProduto = regra.IdProduto,
                NomeProduto = regra.Produto?.NomeProduto ?? string.Empty,
                Categoria = regra.Categoria.ToString(),
                Prioridade = regra.Prioridade.ToString(),
                TempoResposta = regra.TempoResposta.ToString(@"hh\:mm\:ss"),
                TempoResolucao = regra.TempoResolucao.ToString(@"hh\:mm\:ss")
            };
        }
    }
}