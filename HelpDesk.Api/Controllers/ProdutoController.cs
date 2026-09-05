using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{   
    /// <summary>
    /// Controlador responsável por gerenciar operações relacionadas a produtos no sistema de Help Desk.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        AppDbContext _appDbContext;
        IProdutoService _produtoService;

        /// <summary>
        /// Inicializa uma nova instância do controlador de produto com o contexto do banco de dados e o serviço de produto.
        /// </summary>
        /// <param name="appDbContext">O contexto do banco de dados.</param>
        /// <param name="produtoService">O serviço de produto.</param>
        public ProdutoController(AppDbContext appDbContext, IProdutoService produtoService)
        {
            _appDbContext = appDbContext;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Adiciona um novo produto ao sistema de Help Desk.
        /// </summary>
        /// <param name="produto">Os dados do produto a ser adicionado.</param>
        /// <returns>Os dados do produto adicionado.</returns>
        public async Task<IActionResult> AddProduto(ProdutoRequestDTO produto)
        {
            var novoProduto = await _produtoService.AddProdutoAsync(produto);
            return Ok(novoProduto);
        }

        /// <summary>
        /// Obtém um produto pelo nome.
        /// </summary>
        /// <param name="nome">O nome do produto a ser obtido.</param>
        /// <returns>Os dados do produto obtido.</returns>
        public async Task<IActionResult> GetProdutoByNome(string nome)
        {
            var produto = await _produtoService.GetProdutoByNomeAsync(nome);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        /// <summary>
        /// Obtém um produto pelo ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>Os dados do produto obtido.</returns>
        public async Task<IActionResult> GetProdutoById(long id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        /// <summary>
        /// Obtém uma lista de produtos que correspondem a um termo de busca.
        /// </summary>
        /// <param name="termo">O termo de busca.</param>
        /// <returns>Uma lista de produtos que correspondem ao termo de busca.</returns>
        public async Task<IActionResult> GetProdutoByTermo(string termo)
        {
            var produtos = await _produtoService.GetProdutoByTermoAsync(termo);
            if (produtos == null || produtos.Count == 0)
            {
                return NotFound("Nenhum produto encontrado.");
            }
            return Ok(produtos);
        }
        
        /// <summary>
        /// Obtém todos os produtos cadastrados no sistema de Help Desk.
        /// </summary>
        /// <returns>Uma lista de todos os produtos cadastrados.</returns>
        public async Task<IActionResult> GetAllProdutos()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            if (produtos == null || produtos.Count == 0)
            {
                return NotFound("Nenhum produto encontrado.");
            }
            return Ok(produtos);
        }

        /// <summary>
        /// Obtém todos os produtos com status falso.
        /// </summary>
        /// <returns>Uma lista de produtos com status falso.</returns>
        public async Task<IActionResult> GetAllProdutosByStatusFalse()
        {
            var produtos = await _produtoService.GetAllProdutosByStatusFalseAsync();
            if (produtos == null || produtos.Count == 0)
            {
                return NotFound("Nenhum produto encontrado.");
            }
            return Ok(produtos);
        }

        /// <summary>
        /// Atualiza um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="nomeProduto">O novo nome do produto.</param>
        /// <returns>O produto atualizado.</returns>
        public async Task<IActionResult> UpdateProduto(long id, string nomeProduto)
        {
            var produtoAtualizado = await _produtoService.UpdateProdutoAsync(id, nomeProduto);
            return Ok(produtoAtualizado);
        }
    }
}