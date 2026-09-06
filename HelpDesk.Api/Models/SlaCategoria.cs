using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Representa uma Regra SLA no sistema de Help Desk.
    /// </summary>
    [Table("sla_categorias")]
    public class SlaCategoria
    {
        /// <summary>
        /// Obtém ou define o identificador único do chamado.
        /// </summary>
        /// <example>1</example>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o ID do produto associado.
        /// </summary>
        /// <example>1</example>
        [Required]
        [Column("produto_id")]
        public long IdProduto { get; set; }

        /// <summary>
        /// Propriedade de navegação para o produto relacionado.
        /// </summary>
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        /// <summary>
        /// Obtém ou define a categoria do chamado.
        /// </summary>
        /// <example>1</example>
        [Required]
        [Column("categoria", TypeName = "varchar(20)")]
        public CategoriaEnum Categoria { get; set; }

        /// <summary>
        /// Obtém ou define a prioridade do chamado.
        /// </summary>
        /// <example>3</example>
        [Required]
        [Column("prioridade", TypeName = "varchar(20)")]
        public PrioridadeEnum Prioridade { get; set; }

        /// <summary>
        /// Obtém ou define o Tempo de Resposta do chamado.
        /// </summary>
        /// <example>3</example>
        [Required]
        [Column("tempo_resposta", TypeName = "interval")]
        public TimeSpan TempoResposta { get; set; }

        /// <summary>
        /// Obtém ou define o Tempo de Resolução do chamado.
        /// </summary>
        /// <example>3</example>
        [Required]
        [Column("tempo_resolucao", TypeName = "interval")]
        public TimeSpan TempoResolucao { get; set; }
    }
}