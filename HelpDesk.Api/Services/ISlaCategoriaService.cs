using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;

namespace HelpDesk.Api.Services
{   
    /// <summary>
    /// Interface que define os métodos para o serviço de Regras SLA no sistema de Help Desk.
    /// </summary>
    public interface ISlaCategoriaService
    {
        /// <summary>
        /// Busca todas as Regras SLA no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista de DTO das regras existentes.</returns>
        Task<IEnumerable<SlaCategoriaResponseDTO>> GetAllAsync();

        /// <summary>
        /// Busca uma Regras SLA pelo ID no sistema de Help Desk. Pode ser nulo.
        /// </summary>
        /// <returns>DTO da regra se existente.</returns>
        Task<SlaCategoriaResponseDTO?> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="novaRegra">DTO com os dados na nova regra a ser inserida</param>
        /// <returns>DTO da regra criada</returns> 
        Task<SlaCategoriaResponseDTO> CreateRuleAsync(SlaCategoriaRequestDTO novaRegra);

        /// <summary>
        /// Atualiza uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra que será atualizada</param>
        /// <param name="regraAtualizada">DTO com os nvos dados da regra</param>
        /// <returns>Confirmação de atualização (true ou false)</returns> 
        Task<bool> UpdateRuleAsync(int id, SlaCategoriaRequestDTO regraAtualizada);

        /// <summary>
        /// Deleta uma Regra SLA no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra a ser excluída</param>
        /// <returns>Confirmação de exclusão (true ou false)</returns> 
        Task<bool> DeleteRuleAsync(int id);
    }
}