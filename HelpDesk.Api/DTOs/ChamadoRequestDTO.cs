using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Models;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para requisição de criação de um novo Chamado no sistema de Help Desk.
    /// </summary>
    public class ChamadoRequestDTO
    {
        /// <summary>
        /// Define o identificador único do grupo cliente do produto associado ao chamado.
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public long IdCliente { get; set; }

        /// <summary>
        /// Ddefine o identificador único da empresa associada ao cliente.
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID da empresa é obrigatório.")]
        public long IdEmpresa { get; set; }

        /// <summary>
        /// Define o identificador único do produto associado ao chamado.
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public long IdProduto { get; set; }

        /// <summary>
        /// Define o título do chamado.
        /// </summary>
        /// <example>Bug na autorização</example>
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Define a descrição do chamado.
        /// </summary>
        /// <example>Texto...</example>
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Define a prioridade do chamado. 1 = Baixa, 2 = Média, 3 = Alta, 4 = Urgente.
        /// </summary>
        /// <example>3</example>
        [Required(ErrorMessage = "A prioridade é obrigatória.")]
        public PrioridadeEnum Prioridade { get; set; }

        /// <summary>
        /// Define a categoria do chamado. 1 = Bugs, 2 = Interface, 3 = Lógica.
        /// </summary>
        /// <example>2</example>
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaEnum Categoria { get; set; }
    }
}