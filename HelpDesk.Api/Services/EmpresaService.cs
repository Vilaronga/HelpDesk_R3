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
    /// Implementação do serviço de empresa, responsável por gerenciar operações relacionadas a empresas no sistema de Help Desk.
    /// </summary>
    public class EmpresaService : IEmpresaService
    {
        AppDbContext _appDbContext;

        /// <summary>
        /// Inicializa uma nova instância do serviço de empresa com o contexto do banco de dados.
        /// </summary>
        /// <param name="appDbContext"></param>
        public EmpresaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Adiciona uma nova empresa ao sistema de Help Desk.
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns>Retorna a empresa adicionada.</returns>
        /// <exception cref="Exception">A empresa já está cadastrada.</exception>
        public async Task<EmpresaResponseDTO> AddEmpresaAsync(EmpresaRequestDTO empresa)
        {   

            var nomeExists = await _appDbContext.Empresa.AnyAsync(e => e.NomeEmpresa == empresa.Nome);
            if (nomeExists)
            {
                throw new Exception("A empresa já está cadastrada.");
            }

            var newEmpresa = new Empresa
            {
                NomeEmpresa = empresa.Nome,
                DataCadastroEmpresa = DateTime.UtcNow
            };

            _appDbContext.Empresa.Add(newEmpresa);
            await _appDbContext.SaveChangesAsync();

            return new EmpresaResponseDTO
            {
                Nome = newEmpresa.NomeEmpresa
            };
        }

        /// <summary>
        /// Obtém uma empresa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns>DTO da empresa</returns>
        public async Task<EmpresaResponseDTO> GetEmpresaByIdAsync(long id)
        {
            var empresa = await _appDbContext.Empresa.FirstOrDefaultAsync(e => e.IdEmpresa == id);

            if (empresa == null)
            {
                return null;
            }

            return new EmpresaResponseDTO
            {
                Nome = empresa.NomeEmpresa
            };
        }

        /// <summary>
        /// Obtém uma empresa pelo termo.
        /// </summary>
        /// <param name="nome">Termo de busca</param>
        /// <returns>Lista de empresas que correspondem ao termo de busca.</returns>
        public async Task<List<EmpresaResponseDTO>> GetEmpresaByTermoAsync(string nome)
        {   
            string termo = $"%{nome}%";

            var empresas = await _appDbContext.Empresa.Where(e => EF.Functions.Like(e.NomeEmpresa, termo)).ToListAsync();

            if (empresas == null)
            {
                return null;
            }

            return empresas.Select(e => new EmpresaResponseDTO
            {
                Nome = e.NomeEmpresa
            }).ToList();
        }

        /// <summary>
        /// Obtém uma empresa pelo seu nome.
        /// </summary>
        /// <param name="nome">Nome da empresa</param>
        /// <returns>DTO da empresa</returns>
        public async Task<EmpresaResponseDTO> GetEmpresaByNomeAsync(string nome)
        {
            var empresa = await _appDbContext.Empresa.FirstOrDefaultAsync(e => e.NomeEmpresa == nome);

            if (empresa == null)
            {
                return null;
            }

            return new EmpresaResponseDTO
            {
                Nome = empresa.NomeEmpresa
            };
        }
        
        /// <summary>
        /// Obtém todas as empresas cadastradas no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista de DTOs com os dados das empresas cadastradas.</returns>
        public async Task<List<EmpresaResponseDTO>> GetAllEmpresasAsync()
        {
            var empresas = await _appDbContext.Empresa.ToListAsync();

            if (empresas == null)
            {
                return null;
            }

            return empresas.Select(e => new EmpresaResponseDTO
            {
                Nome = e.NomeEmpresa
            }).ToList();
        }
    }
}