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
    /// Controlador responsável por gerenciar operações relacionadas a empresas no sistema de Help Desk.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        AppDbContext _appDbContext;
        IEmpresaService _empresaService;

        /// <summary>
        /// Inicializa uma nova instância do controlador de empresa com o contexto do banco de dados e o serviço de empresa.
        /// </summary>
        /// <param name="appDbContext">O contexto do banco de dados.</param>
        /// <param name="empresaService">O serviço de empresa.</param>
        public EmpresaController(AppDbContext appDbContext, IEmpresaService empresaService)
        {
            _appDbContext = appDbContext;
            _empresaService = empresaService;
        }

        /// <summary>
        /// Cria uma nova empresa no sistema de Help Desk.
        /// </summary>
        /// <param name="empresa">Os dados da empresa a ser criada.</param>
        /// <returns>Os dados da empresa criada.</returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarEmpresa(EmpresaRequestDTO empresa)
        {
            var novaEmpresa = await _empresaService.AddEmpresaAsync(empresa);
            return Ok(novaEmpresa);
        }

        /// <summary>
        /// Busca todas as empresas cadastradas no sistema de Help Desk.
        /// </summary>
        /// <returns>Lista de empresas cadastradas.</returns>
        [HttpGet]
        public async Task<IActionResult> BuscarEmpresas()
        {
            var empresas = await _empresaService.GetAllEmpresasAsync();
            return Ok(empresas);
        }

        /// <summary>
        /// Busca uma empresa pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da empresa a ser buscada.</param>
        /// <returns>Os dados da empresa encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarEmpresaPorId(long id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);
            return Ok(empresa);
        }

        /// <summary>
        /// Busca empresas cujo nome contenha o termo especificado.
        /// </summary>
        /// <param name="termo">O termo de busca.</param>
        /// <returns>Lista de empresas que correspondem ao termo de busca.</returns>
        [HttpGet("buscar/termo/{termo}")]
        public async Task<IActionResult> BuscarEmpresasPorTermo(string termo)
        {
            var empresas = await _empresaService.GetEmpresaByTermoAsync(termo);
            return Ok(empresas);
        }

        /// <summary>
        /// Busca uma empresa pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome da empresa a ser buscada.</param>
        /// <returns>Os dados da empresa encontrada.</returns>
        [HttpGet("buscar/nome/{nome}")]
        public async Task<IActionResult> BuscarEmpresasPorNome(string nome)
        {
            var empresas = await _empresaService.GetEmpresaByNomeAsync(nome);
            return Ok(empresas);
        }
    }
}