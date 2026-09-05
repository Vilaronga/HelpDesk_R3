using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Services
{
    /// <summary>
    /// Implementação do serviço de produtos, responsável por gerenciar operações relacionadas a produtos no sistema de Help Desk.
    /// </summary>
    public class ProdutoService : IProdutoService
    {
        AppDbContext _appDbContext;

        /// <summary>
        /// Inicializa uma nova instância do serviço de produtos com o contexto do banco de dados.
        /// </summary>
        /// <param name="appDbContext"></param>
        public ProdutoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Adiciona um novo produto ao sistema de Help Desk.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ProdutoResponseDTO> AddProdutoAsync(ProdutoRequestDTO produto)
        {

            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            var novoProduto = new Models.Produto(produto.NomeProduto, DateTime.Now);
            _appDbContext.Produto.Add(novoProduto);
            await _appDbContext.SaveChangesAsync();

            return new ProdutoResponseDTO
            {
                NomeProduto = novoProduto.NomeProduto
            };
        }

        /// <summary>
        /// Obtém um produto pelo seu nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Retorna o produto encontrado ou null se não for encontrado.</returns>
        public async Task<ProdutoResponseDTO> GetProdutoByNomeAsync(string nome)
        {
            var produto = await _appDbContext.Produto
                .FirstOrDefaultAsync(p => p.NomeProduto == nome);

            if (produto == null)
            {
                return null;
            }

            return new ProdutoResponseDTO
            {
                NomeProduto = produto.NomeProduto
            };
        }

        /// <summary>
        /// Obtém um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>Retorna o produto encontrado ou null se não for encontrado.</returns>
        public async Task<ProdutoResponseDTO> GetProdutoByIdAsync(long id)
        {
            var produto = await _appDbContext.Produto
                .FirstOrDefaultAsync(p => p.IdProduto == id);

            if (produto == null)
            {
                return null;
            }

            return new ProdutoResponseDTO
            {
                NomeProduto = produto.NomeProduto
            };
        }

        /// <summary>
        /// Obtém uma lista de produtos que correspondem a um termo de busca.
        /// </summary>
        /// <param name="termo">O termo de busca.</param>
        /// <returns>Retorna uma lista de produtos encontrados ou null se nenhum for encontrado.</returns>
        public async Task<List<ProdutoResponseDTO>> GetProdutoByTermoAsync(string termo)
        {
            string termoBusca = $"%{termo}%";

            var produtos = await _appDbContext.Produto
                .Where(p => EF.Functions.Like(p.NomeProduto, termoBusca))
                .ToListAsync();

            if (produtos == null || produtos.Count == 0)
            {
                return null;
            }

            return produtos.Select(p => new ProdutoResponseDTO
            {
                NomeProduto = p.NomeProduto
            }).ToList();
        }

        /// <summary>
        /// Obtém todos os produtos cadastrados no sistema de Help Desk.
        /// </summary>
        /// <returns>Retorna uma lista de todos os produtos cadastrados ou null se não houver nenhum.</returns>
        public async Task<List<ProdutoResponseDTO>> GetAllProdutosAsync()
        {
            var produtos = await _appDbContext.Produto.ToListAsync();

            if (produtos == null || produtos.Count == 0)
            {
                return null;
            }

            return produtos.Select(p => new ProdutoResponseDTO
            {
                NomeProduto = p.NomeProduto
            }).ToList();
        }

        /// <summary>
        /// Atualiza a data de atualização de um produto pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="nomeProduto">O novo nome do produto.</param>
        /// <returns>Retorna o produto atualizado ou null se não for encontrado.</returns>
        public async Task<ProdutoResponseDTO> UpdateProdutoAsync(long id, string nomeProduto)
        {
            var produto = await _appDbContext.Produto.FirstOrDefaultAsync(p => p.IdProduto == id);

            if (produto == null)
            {
                throw new ArgumentException($"Produto com ID {id} não encontrado.", nameof(id));
            }

            produto.NomeProduto = nomeProduto;
            produto.DataAtualizacaoProduto = DateTime.Now;

            _appDbContext.Produto.Update(produto);
            await _appDbContext.SaveChangesAsync();

            return new ProdutoResponseDTO
            {
                NomeProduto = produto.NomeProduto
            };
        }

        /// <summary>
        /// Obtém todos os produtos que estão inativos (ProdutoAtivo = false).
        /// </summary>
        /// <returns>Retorna uma lista de produtos inativos ou null se não houver nenhum.</returns>
        public async Task<List<ProdutoResponseDTO>> GetAllProdutosByStatusFalseAsync()
        {
            var produtos = await _appDbContext.Produto
                .Where(p => p.ProdutoAtivo == false)
                .ToListAsync();

            if (produtos == null || produtos.Count == 0)
            {
                return null;
            }

            return produtos.Select(p => new ProdutoResponseDTO
            {
                NomeProduto = p.NomeProduto
            }).ToList();
        }
    }
}