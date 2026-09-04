using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Interface que define os métodos para o serviço de empresa, responsável por gerenciar operações relacionadas a empresas no sistema de Help Desk.
    /// </summary>
    public interface IEmpresaService
    {
        /// <summary>
        /// Adiciona uma nova empresa ao sistema de Help Desk.
        /// </summary>
        /// <param name="empresa">DTO com os dados da empresa a ser criada.</param>
        /// <returns>DTO com os dados da empresa criada.</returns>
        Task<EmpresaResponseDTO> AddEmpresaAsync(EmpresaRequestDTO empresa);

        /// <summary>
        /// Busca uma empresa pelo seu nome.
        /// </summary>
        /// <param name="nome">Nome da empresa a ser buscada.</param>
        /// <returns>DTO com os dados da empresa encontrada.</returns>
        Task<EmpresaResponseDTO> GetEmpresaByNomeAsync(string nome);

        /// <summary>
        /// Busca uma empresa pelo seu ID.
        /// </summary>
        /// <param name="id">ID da empresa a ser buscada.</param>
        /// <returns>DTO com os dados da empresa encontrada.</returns>
        Task<EmpresaResponseDTO> GetEmpresaByIdAsync(long id);

        /// <summary>
        /// Busca empresas cujo nome contenha o termo especificado.
        /// </summary>
        /// <param name="termo">Termo a ser pesquisado no nome das empresas.</param>
        /// <returns>Lista de DTOs com os dados das empresas encontradas.</returns>
        Task<List<EmpresaResponseDTO>> GetEmpresaByTermoAsync(string termo);

        /// <summary>
        /// Busca todas as empresas cadastradas no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista de DTOs com os dados das empresas cadastradas.</returns>
        Task<List<EmpresaResponseDTO>> GetAllEmpresasAsync();
    }
}