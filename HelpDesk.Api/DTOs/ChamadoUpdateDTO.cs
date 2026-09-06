using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Models;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para atulizar informações de um Chamado no sistema de Help Desk.
    /// </summary>
    public class ChamadoUpdateDTO
    {
        /// <summary>
        /// Atualiza o colaborador responsável pelo chamado
        /// </summary>
        [Required(ErrorMessage = "O id do colaborador responsável é obrigatório!")]
        public long? IdColaborador { get; set; }

        /// <summary>
        /// Atualiza o título do chamado
        /// </summary>
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Atualiza a descrição do chamado
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Atualiza status do chamado
        /// </summary>
        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Atualiza a prioridade do chamado
        /// </summary>
        [Required(ErrorMessage = "A prioridade é obrigatória.")]
        public PrioridadeEnum Prioridade { get; set; }

        /// <summary>
        /// Atualiza a categoria do chamado
        /// </summary>
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaEnum Categoria { get; set; }

        /// <summary>
        /// Atualiza o Produto do chamado
        /// </summary>
        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public long IdProduto { get; set; }
    }
}