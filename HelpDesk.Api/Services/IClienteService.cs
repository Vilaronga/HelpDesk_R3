using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;

namespace HelpDesk.Api.Services
{
    public interface IClienteService
    {
        Task<ClienteResponseDTO> GetClienteByIdAsync(long id);
        Task<ClienteResponseDTO> GetClienteByCpfAsync(string cpf);
        Task<ClienteResponseDTO> GetClienteByEmailAsync(string email);
        Task<List<ClienteResponseDTO>> GetAllClientesAsync();
        Task<AddClienteDTO> AddClienteAsync(AddClienteDTO addClienteDTO);

        Task<List<ClienteResponseDTO>> GetClientesByNomeAsync(string nome);
    }
}