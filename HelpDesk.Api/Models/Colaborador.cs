using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Representa um Colaborador no sistema de Help Desk.
    /// </summary>
    [Table("colaborador")]
    public class Colaborador
    {
        /// <summary>
        /// Obtém ou define o identificador único do colaborador.
        /// </summary>
        /// <example>1</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_colaborador")]
        public long IdColaborador { get; set; }

        /// <summary>
        /// Obtém ou define o nome do colaborador.
        /// </summary>
        /// <example>Maria Oliveira</example>
        [Column("nome_colaborador", TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o email do colaborador.
        /// </summary>
        /// <example>maria.oliveira@exemplo.com</example>
        [Column("email_colaborador", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o CPF do colaborador.
        /// </summary>
        /// <example>12345678900</example>
        [Column("cpf_colaborador", TypeName = "varchar(11)")]
        [Required]
        public string Cpf { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o telefone do colaborador.
        /// </summary>
        /// <example>11999999999</example>
        [Column("telefone_colaborador", TypeName = "varchar(11)")]
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a data de cadastro do colaborador.
        /// </summary>
        /// <example>2026-03-01T15:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_colaborador", TypeName = "timestamp")]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Obtém ou define a data de atualização do colaborador.
        /// </summary>
        /// <example>2026-03-01T15:30:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_atualizacao_colaborador", TypeName = "timestamp")]
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Obtém ou define se o colaborador está ativo no sistema.
        /// </summary>
        /// <example>true</example>
        [Column("colaborador_ativo")]
        public bool ColaboradorAtivo { get; set;}

        /// <summary>
        /// Inicializa uma nova instância da classe Colaborador.
        /// </summary>
        /// <example>Colaborador colaborador = new Colaborador();</example>
        public Colaborador() { }

        /// <summary>
        /// Inicializa uma nova instância da classe Colaborador com os parâmetros fornecidos.
        /// </summary>
        /// <param name="nome">Nome do colaborador</param>
        /// <param name="email">Email do colaborador</param>
        /// <param name="cpf">CPF do colaborador</param>
        /// <param name="telefone">Telefone do colaborador</param>
        /// <param name="dataCadastro">Data de cadastro do colaborador</param>
        public Colaborador(string nome, string email, string cpf, string telefone, DateTime dataCadastro)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            DataCadastro = dataCadastro;
            DataAtualizacao = dataCadastro;
            ColaboradorAtivo = true;
        }
    }
}
