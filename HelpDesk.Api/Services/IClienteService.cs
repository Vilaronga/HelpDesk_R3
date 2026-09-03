using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Interface que define os métodos para o serviço de gerenciamento de clientes no sistema de Help Desk.
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Obtém um cliente pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do cliente.</param>
        /// <returns>O DTO com os dados do cliente encontrado.</returns>
        Task<ClienteResponseDTO> GetClienteByIdAsync(long id);

        //Task<ClienteResponseDTO> GetClienteByCpfAsync(string cpf);

        /// <summary>
        /// Obtém um cliente pelo seu e-mail.
        /// </summary>
        /// <param name="email">O e-mail do cliente.</param>
        /// <returns>O DTO com os dados do cliente encontrado.</returns>
        Task<ClienteResponseDTO> GetClienteByEmailAsync(string email);

        /// <summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns>Uma lista de DTOs com os dados dos clientes encontrados.</returns>
        Task<List<ClienteResponseDTO>> GetAllClientesAsync();

        /// <summary>
        /// Adiciona um novo cliente ao sistema de Help Desk.
        /// </summary>
        /// <param name="addClienteDTO">O DTO com os dados do cliente a ser adicionado.</param>
        /// <returns>O DTO com os dados do cliente adicionado.</returns>
        Task<AddClienteDTO> AddClienteAsync(AddClienteDTO addClienteDTO);

        /// <summary>
        /// Obtém clientes pelo seu nome ou termo de busca.
        /// </summary>
        /// <param name="nome">O nome do cliente ou termo de busca.</param>
        /// <returns>Uma lista de DTOs com os dados dos clientes encontrados.</returns>
        Task<List<ClienteResponseDTO>> GetClientesByNomeAsync(string nome);
    }
}