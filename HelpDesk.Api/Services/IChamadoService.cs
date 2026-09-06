using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Models;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Interface que define os métodos para o serviço de gerenciamento de chamados no sistema de Help Desk.
    /// </summary>
    public interface IChamadoService
    {   
        /// <summary>
        /// Adiciona um novo chamado ao sistema de Help Desk.
        /// </summary>
        /// <param name="chamadoRequestDTO">O DTO com os dados do chamado a ser adicionado.</param>
        /// <returns>O DTO com os dados do chamado adicionado.</returns>
        Task<ChamadoResponseDTO> AddChamadoAsync(ChamadoRequestDTO chamadoRequestDTO);

        /// <summary>
        /// Atualiza um novo chamado ao sistema de Help Desk.
        /// </summary>
        /// <param name="chamadoAtualizado">O DTO contendo os novos dados do chamado a ser atualizado.</param>
        /// <returns>Confirmação se foi ou não atualizado (true ou false).</returns>
        Task<bool> UpdateChamadoAsync(Guid guid, ChamadoUpdateDTO chamadoAtualizado);

        /// <summary>
        /// Busca um chamado no sistema de Help Desk pelo código Público.
        /// </summary>
        /// <param name="guid">Código Público do chamado a ser adicionado.</param>
        /// <returns>O DTO com os dados do chamado aberto.</returns>
        Task<ChamadoResponseDTO> GetChamadoByGuidAsync(Guid guid);
    }
}