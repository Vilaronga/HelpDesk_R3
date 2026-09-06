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
        [Column("id")]
        public long IdCliente { get; set; }

        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        /// <example>João da Silva</example>
        [Column("nome", TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o email do cliente.
        /// </summary>
        /// <example>joao.silva@exemplo.com</example>
        [Column("email", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o identificador numérico da empresa associada (Chave Estrangeira).
        /// </summary>
        /// <example>1</example>
        [Column("grupo_empresa_id")]
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
        [Column("data_cadastro_cliente", TypeName = "timestamp with time zone")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

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
        /// <param name="idEmpresa">Identificador único da empresa associada</param>
        public Cliente(string nome, string email, long idEmpresa)
        {
            Nome = nome;
            Email = email;
            IdEmpresa = idEmpresa;
        }
    }
}
