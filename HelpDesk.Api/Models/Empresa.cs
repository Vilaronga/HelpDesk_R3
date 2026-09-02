using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa uma Empresa no banco de dados.
    /// </summary>
    [Table("empresa")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_empresa")]
        public long IdEmpresa { get; set; }

        [Column("nome_empresa", TypeName = "varchar(50)")]
        public string NomeEmpresa { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_empresa", TypeName = "datetime")]
        public DateTime DataCadastroEmpresa { get; set; }
    }
}