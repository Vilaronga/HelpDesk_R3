using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Models;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para requisição de criação de uma nova Regra SLA no sistema de Help Desk.
    /// </summary>
    public class SlaCategoriaRequestDTO
    {   
        /// <summary>
        /// Define o identificador único do produto associado ao chamado.
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public long IdProduto { get; set; }

        /// <summary>
        /// Define a categoria do chamado. 1 = Bugs, 2 = Interface, 3 = Lógica.
        /// </summary>
        /// <example>2</example>
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaEnum Categoria { get; set; }

        /// <summary>
        /// Define a prioridade do chamado. 1 = Baixa, 2 = Média, 3 = Alta, 4 = Urgente.
        /// </summary>
        /// <example>3</example>
        [Required(ErrorMessage = "A prioridade é obrigatória.")]
        public PrioridadeEnum Prioridade { get; set; }

        /// <summary>
        /// Define um tempo de resposta padrão para esse conjunto (situação).
        /// </summary>
        /// <example>3</example>
        [Range(1, int.MaxValue, ErrorMessage = "O tempo de resposta deve ser maior que zero.")]
        public int TempoRespostaMinutos { get; set; }

        /// <summary>
        /// Define um tempo de resolução padrão para esse conjunto (situação).
        /// </summary>
        /// <example>3</example>
        [Range(1, int.MaxValue, ErrorMessage = "O tempo de resolução deve ser maior que zero.")]
        public int TempoResolucaoMinutos { get; set; }
    }
}