using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Esta classe representa um Cliente no banco de dados.
    /// </summary>
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("nome_cliente", TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Column("email_cliente", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("cpf_cliente", TypeName = "varchar(11)")]
        [Required]
        public string Cpf { get; set; } = string.Empty;

        [Column("telefone_cliente", TypeName = "varchar(11)")]
        public string Telefone { get; set; } = string.Empty;

        [Column("fk_id_empresa_cliente", TypeName = "varchar(100)")]
        [Required]
        public string Empresa { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_cliente", TypeName = "datetime")]
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