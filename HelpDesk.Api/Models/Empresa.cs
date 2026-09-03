using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa uma Empresa no banco de dados.
    /// </summary>
    [Table("empresa")]
    public class Empresa
    {
        /// <summary>
        /// Obtém ou define o identificador único da empresa.
        /// </summary>
        /// <example>1</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_empresa")]
        public long IdEmpresa { get; set; }

        /// <summary>
        /// Obtém ou define o nome da empresa.
        /// </summary>
        /// <example>Acme Inc.</example>
        [Column("nome_empresa", TypeName = "varchar(50)")]
        [Required]
        public string NomeEmpresa { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a data de cadastro da empresa.
        /// </summary>
        /// <example>2026-03-01T00:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_empresa", TypeName = "timestamp")]
        public DateTime DataCadastroEmpresa { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe Empresa.
        /// </summary>
        /// <example>Empresa empresa = new Empresa();</example>
        public Empresa()
        {
            
        }

        /// <summary>
        /// Inicializa uma nova instância da classe Empresa com os parâmetros fornecidos.
        /// </summary>
        /// <param name="nomeEmpresa">Nome da empresa.</param>
        /// <param name="dataCadastroEmpresa">Data de cadastro da empresa.</param>
        public Empresa(string nomeEmpresa, DateTime dataCadastroEmpresa)
        {
            NomeEmpresa = nomeEmpresa;
            DataCadastroEmpresa = dataCadastroEmpresa;
        }
    }
}
