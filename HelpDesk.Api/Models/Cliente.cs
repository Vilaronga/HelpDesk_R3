using System;
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
        /// <summary>
        /// Obtém ou define o identificador único do cliente.
        /// </summary>
        /// <example>1</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_cliente")]
        public long IdCliente { get; set; }

        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        /// <example>João da Silva</example>
        [Column("nome_cliente", TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o email do cliente.
        /// </summary>
        /// <example>joao.silva@exemplo.com</example>
        [Column("email_cliente", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o telefone do cliente.
        /// </summary>
        /// <example>11999999999</example>
        [Column("telefone_cliente", TypeName = "varchar(11)")]
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o identificador numérico da empresa associada (Chave Estrangeira).
        /// </summary>
        /// <example>1</example>
        [Column("fk_id_empresa_cliente")]
        public long IdEmpresa { get; set; }

        /// <summary>
        /// Propriedade de navegação para obter ou definir a empresa associada ao cliente.
        /// </summary>
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; }

        /// <summary>
        /// Obtém ou define a data de cadastro do cliente.
        /// </summary>
        /// <example>2026-03-01T00:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_cadastro_cliente", TypeName = "timestamp")]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe Cliente.
        /// </summary>
        /// <example>Cliente cliente = new Cliente();</example>
        public Cliente() { }

        /// <summary>
        /// Inicializa uma nova instância da classe Cliente com os parâmetros fornecidos usando o ID da Empresa.
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="email">Email do cliente</param>
        /// <param name="telefone">Telefone do cliente</param>
        /// <param name="idEmpresa">Identificador único da empresa associada</param>
        /// <param name="dataCadastro">Data de cadastro do cliente</param>
        public Cliente(string nome, string email, string telefone, long idEmpresa, DateTime dataCadastro)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdEmpresa = idEmpresa;
            DataCadastro = dataCadastro;
        }
    }
}
