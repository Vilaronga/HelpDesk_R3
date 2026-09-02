using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa um Produto no banco de dados.
    /// </summary>
    [Table("produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_produto")]
        public long IdProduto { get; set; }

        [Column("nome_produto", TypeName = "varchar(50)")]
        public string NomeProduto { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_produto", TypeName = "datetime")]
        public DateTime DataCadastroProduto { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_exclusao_produto", TypeName = "datetime")]
        public DateTime DataExcusaoProduto { get; set; }

        [Column("produto_ativo")]
        public bool ProdutoAtivo { get; set;}
    }
}