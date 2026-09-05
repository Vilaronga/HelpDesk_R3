using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.DTOs;

namespace HelpDesk.Api.Services
{   
    /// <summary>
    /// Interface que define os métodos para o serviço de produto, responsável por gerenciar operações relacionadas a produtos no sistema de Help Desk.
    /// </summary>
    public interface IProdutoService
    {   
        /// <summary>
        /// Adiciona um novo produto ao sistema de Help Desk.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        /// <returns>O produto adicionado ou null se não for possível adicionar.</returns>
        Task<ProdutoResponseDTO> AddProdutoAsync(ProdutoRequestDTO produto);

        /// <summary>
        /// Obtém um produto pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do produto a ser obtido.</param>
        /// <returns>Retorna o produto encontrado ou null se não for encontrado.</returns>
        Task<ProdutoResponseDTO> GetProdutoByNomeAsync(string nome);

        /// <summary>
        /// Obtém um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>Retorna o produto encontrado ou null se não for encontrado.</returns>
        Task<ProdutoResponseDTO> GetProdutoByIdAsync(long id);

        /// <summary>
        /// Obtém uma lista de produtos que correspondem a um termo de busca.
        /// </summary>
        /// <param name="termo">O termo de busca.</param>
        /// <returns>Retorna uma lista de produtos encontrados ou null se nenhum for encontrado.</returns>
        Task<List<ProdutoResponseDTO>> GetProdutoByTermoAsync(string termo);

        /// <summary>
        /// Obtém todos os produtos cadastrados no sistema de Help Desk.
        /// </summary>
        /// <returns>Retorna uma lista de todos os produtos cadastrados ou null se não houver nenhum.</returns>
        Task<List<ProdutoResponseDTO>> GetAllProdutosAsync();

        /// <summary>
        /// Atualiza um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="nomeProduto">O novo nome do produto.</param>
        /// <returns>Retorna o produto atualizado ou null se não for encontrado.</returns>
        Task<ProdutoResponseDTO> UpdateProdutoAsync(long id, string nomeProduto);

        /// <summary>
        /// Obtém todos os produtos que estão inativos (ProdutoAtivo = false).
        /// </summary>
        /// <returns>Retorna uma lista de produtos inativos ou null se não houver nenhum.</returns>
        Task<List<ProdutoResponseDTO>> GetAllProdutosByStatusFalseAsync();
    }
}