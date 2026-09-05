using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa um Produto no banco de dados.
    /// </summary>
    [Table("produto")]
    public class Produto
    {
        /// <summary>
        /// Obtém ou define o identificador único do produto.
        /// </summary>
        /// <example>1</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_produto")]
        public long IdProduto { get; set; }

        /// <summary>
        /// Obtém ou define o nome do produto.
        /// </summary>
        /// <example>Sistema X</example>
        [Column("nome_produto", TypeName = "varchar(50)")]
        [Required]
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a data de cadastro do produto.
        /// </summary>
        /// <example>2026-03-01T00:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_produto", TypeName = "timestamp with time zone")]
        public DateTime DataCadastroProduto { get; set; }

        /// <summary>
        /// Obtém ou define a data de atualização do produto.
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_atualizacao_produto", TypeName = "timestamp with time zone")]
        public DateTime DataAtualizacaoProduto { get; set; }

        /// <summary>
        /// Obtém ou define o status do produto (ativo ou inativo).
        /// </summary>
        /// <example>true</example>
        [Column("produto_ativo")]
        public bool ProdutoAtivo { get; set;}

        /// <summary>
        /// Inicializa uma nova instância da classe Produto.
        /// </summary>
        public Produto() { }

        /// <summary>
        /// Inicializa uma nova instância da classe Produto com os parâmetros fornecidos.
        /// </summary>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="dataCadastroProduto">Data de cadastro do produto</param>
        public Produto(string nomeProduto, DateTime dataCadastroProduto)
        {
            NomeProduto = nomeProduto;
            DataCadastroProduto = dataCadastroProduto;
            DataAtualizacaoProduto = dataCadastroProduto;
            ProdutoAtivo = true;
        }
    }
}
