using System.Collections.Generic;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    /// <summary>
    /// Controller responsável por expor os endpoints relacionados às Regras SLA no sistema de Help Desk.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SlaCategoriaController : ControllerBase
    {
        private readonly ISlaCategoriaService _slaCategoriaService;

        /// <summary>
        /// Inicializa uma nova instância do controller de Regras SLA com o serviço injetado.
        /// </summary>
        /// <param name="slaCategoriaService">O serviço de Regras SLA.</param>
        public SlaCategoriaController(ISlaCategoriaService slaCategoriaService)
        {
            _slaCategoriaService = slaCategoriaService;
        }

        /// <summary>
        /// Busca todas as Regras SLA cadastradas no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista das regras existentes.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlaCategoriaResponseDTO>>> GetAll()
        {
            var regras = await _slaCategoriaService.GetAllAsync();
            return Ok(regras);
        }

        /// <summary>
        /// Busca uma Regra SLA pelo ID no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra a ser buscada.</param>
        /// <returns>A regra encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SlaCategoriaResponseDTO>> GetById(int id)
        {
            var regra = await _slaCategoriaService.GetByIdAsync(id);

            if (regra == null)
            {
                return NotFound(new { mensagem = "Regra SLA não encontrada pelo ID: " + id });
            }

            return Ok(regra);
        }

        /// <summary>
        /// Adiciona uma nova Regra SLA ao sistema de Help Desk.
        /// </summary>
        /// <param name="novaRegraDTO">O DTO contendo os dados da nova regra a ser inserida.</param>
        /// <returns>A regra criada.</returns>
        [HttpPost]
        public async Task<ActionResult<SlaCategoriaResponseDTO>> CreateRule(SlaCategoriaRequestDTO novaRegraDTO)
        {
            var regraCriada = await _slaCategoriaService.CreateRuleAsync(novaRegraDTO);
            return Ok(regraCriada);
        }

        /// <summary>
        /// Atualiza uma Regra SLA existente no sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra a ser atualizada.</param>
        /// <param name="regraAtualizadaDTO">O DTO contendo os novos dados da regra.</param>
        /// <returns>Sem conteúdo em caso de sucesso.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRule(int id, SlaCategoriaRequestDTO regraAtualizadaDTO)
        {
            var atualizado = await _slaCategoriaService.UpdateRuleAsync(id, regraAtualizadaDTO);

            if (!atualizado)
            {
                return NotFound(new { mensagem = "Regra SLA não encontrada pelo ID: " + id });
            }

            return Ok("A regra foi atualizada!\n\n" + atualizado);
        }

        /// <summary>
        /// Deleta uma Regra SLA do sistema de Help Desk.
        /// </summary>
        /// <param name="id">ID da regra a ser excluída.</param>
        /// <returns>Sem conteúdo em caso de sucesso.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule(int id)
        {
            var deletado = await _slaCategoriaService.DeleteRuleAsync(id);

            if (!deletado)
            {
                return NotFound(new { mensagem = "Regra SLA não encontrada pelo ID: " + id });
            }

            return Ok("A regra foi excluída!");
        }
    }
}