using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa um cliente no banco de dados.
    /// </summary>
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome", TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("email", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("cpf", TypeName = "varchar(11)")]
        [Required]
        public string Cpf { get; set; } = string.Empty;

        [Column("telefone", TypeName = "varchar(11)")]
        public string Telefone { get; set; } = string.Empty;

        [Column("empresa", TypeName = "varchar(100)")]
        [Required]
        public string Empresa { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column("dataCadastro", TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        public Cliente() { }

        public Cliente(string nome, string email, string cpf, string telefone, string empresa, DateTime dataCadastro)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            Empresa = empresa;
            DataCadastro = dataCadastro;
        }
    }
}