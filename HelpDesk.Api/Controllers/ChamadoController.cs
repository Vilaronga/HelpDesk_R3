using System;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    /// <summary>
    /// Controller responsável por expor os endpoints relacionados a chamados no sistema de Help Desk.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        /// <summary>
        /// Inicializa uma nova instância do controller de chamado com o serviço injetado.
        /// </summary>
        /// <param name="chamadoService">O serviço de chamado.</param>
        public ChamadoController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        /// <summary>
        /// Adiciona um novo chamado ao sistema de Help Desk.
        /// </summary>
        /// <param name="chamadoRequestDTO">O DTO contendo os dados do chamado a ser adicionado.</param>
        /// <returns>O chamado criado.</returns>
        [HttpPost]
        public async Task<ActionResult<ChamadoResponseDTO>> AddChamado(ChamadoRequestDTO chamadoRequestDTO)
        {
            try
            {
                var chamadoCriado = await _chamadoService.AddChamadoAsync(chamadoRequestDTO);
                return Ok(chamadoCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Busca um chamado no sistema de Help Desk pelo código público.
        /// </summary>
        /// <param name="guid">Código público do chamado.</param>
        /// <returns>O chamado encontrado.</returns>
        [HttpGet("{guid}")]
        public async Task<ActionResult<ChamadoResponseDTO>> GetChamadoByGuid(Guid guid)
        {
            try
            {
                var chamado = await _chamadoService.GetChamadoByGuidAsync(guid);
                return Ok(chamado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um chamado existente no sistema de Help Desk.
        /// </summary>
        /// <param name="guid">Código público do chamado a ser atualizado.</param>
        /// <param name="chamadoAtualizado">O DTO contendo os novos dados do chamado.</param>
        /// <returns>Sem conteúdo em caso de sucesso.</returns>
        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateChamado(Guid guid, ChamadoUpdateDTO chamadoAtualizado)
        {
            var atualizado = await _chamadoService.UpdateChamadoAsync(guid, chamadoAtualizado);

            if (!atualizado)
            {
                return NotFound(new { mensagem = "Chamado não encontrado pelo Guid: " + guid });
            }

            return NoContent();
        }
    }
}