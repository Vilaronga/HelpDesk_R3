using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Models;
using HelpDesk.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar as operações relacionadas aos clientes no sistema de Help Desk.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClienteService _clienteService;

        /// <summary>
        /// Inicializa uma nova instância do controlador ClienteController com os serviços necessários.
        /// </summary>
        /// <param name="appDbContext">Recebe o contexto do banco</param>
        /// <param name="clienteService">Recebe o serviço de cliente</param>
        public ClienteController(AppDbContext appDbContext, IClienteService clienteService)
        {
            _appDbContext = appDbContext;
            _clienteService = clienteService;
        }

        /// <summary>
        /// Adiciona um novo cliente ao sistema de Help Desk.
        /// </summary>
        /// <param name="addClienteDTO">DTO contendo os dados do cliente a ser adicionado</param>
        /// <returns>Retorna o cliente adicionado</returns>
        /// <example>await clienteController.AddCliente(new AddClienteDTO { Nome = "João da Silva", Email = "joao.silva@example.com", Cpf = "123.456.789-00", Telefone = "(11) 99999-9999", Empresa = "Acme Inc." });</example>
        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] AddClienteDTO addClienteDTO)
        {
            var cliente = await _clienteService.AddClienteAsync(addClienteDTO);
            return Ok(cliente);
        }

        /// <summary>
        /// Obtém um cliente pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do cliente</param>
        /// <returns>Retorna o cliente encontrado ou NotFound se não for encontrado</returns>
        /// <example>var cliente = await clienteController.GetCliente(1);</example>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(long id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("O cliente de ID: " + id + " não foi encontrado.");
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Obtém clientes pelo seu nome ou termo de busca.
        /// </summary>
        /// <param name="nome">Nome do cliente ou termo de busca</param>
        /// <returns>Retorna a lista de clientes encontrados ou NotFound se nenhum for encontrado</returns>
        /// <example>var clientes = await clienteController.GetClientesByNome("joA");</example>
        [HttpGet("/api/Cliente/nome/{nome}")]
        public async Task<IActionResult> GetClientesByNome(string nome)
        {
            var cliente = await _clienteService.GetClientesByNomeAsync(nome);
            if (cliente.Count == 0)
            {
                return NotFound("Nenhum usuário foi encontrado a partir do termo: " + nome);
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Obtém todos os clientes cadastrados no sistema de Help Desk.
        /// </summary>
        /// <returns>Retorna a lista de clientes encontrados</returns>
        /// <example>var clientes = await clienteController.GetAllClientes();</example>
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }
    }
}