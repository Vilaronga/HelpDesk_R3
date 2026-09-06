using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Api.Models
{   
    /// <summary>
    /// Representa um Chamado no sistema de Help Desk.
    /// </summary>
    [Table("chamado")]
    public class Chamado
    {   
        /// <summary>
        /// Obtém ou define o identificador único do chamado.
        /// </summary>
        /// <example>1</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Obtém ou define o código público do chamado, que é um identificador único para acesso externo.
        /// </summary>
        [Column("codigo_publico", TypeName = "uuid")]
        public Guid CodigoPublico { get; set; }

        /// <summary>
        /// Obtém ou define o ID do cliente autor do chamado.
        /// </summary>
        /// <example>1</example>
        [Column("cliente_id")]
        public long? IdCliente { get; set; }

        /// <summary>
        /// Propriedade de navegação para o cliente que abriu o chamado.
        /// </summary>
        [ForeignKey("IdCliente")]
        public Cliente Autor { get; set; }

        /// <summary>
        /// Obtém ou define o ID da empresa associada.
        /// </summary>
        /// <example>1</example>
        [Column("grupo_empresa_id")]
        public long IdEmpresa { get; set; }

        /// <summary>
        /// Propriedade de navegação para a empresa do chamado.
        /// </summary>
        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; }

        /// <summary>
        /// Obtém ou define o ID do produto associado.
        /// </summary>
        /// <example>1</example>
        [Column("produto_id")]
        public long IdProduto { get; set; }

        /// <summary>
        /// Propriedade de navegação para o produto relacionado.
        /// </summary>
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        /// <summary>
        /// Obtém ou define o ID do colaborador responsável.
        /// </summary>
        /// <example>2</example>
        [Column("colaborador_id")]
        // TODO: Remover esse nullable depois que implementar a atribuição automática de colaborador responsável
        public long? IdColaborador { get; set; }

        /// <summary>
        /// Propriedade de navegação para o colaborador responsável.
        /// </summary>
        [ForeignKey("IdColaborador")]
        // TODO: Remover esse nullable depois que implementar a atribuição automática de colaborador responsável
        public Colaborador? ColaboradorResponsavel { get; set; }

        /// <summary>
        /// Obtém ou define o título do chamado.
        /// </summary>
        /// <example>Problema com o sistema</example>
        [Column("titulo", TypeName = "varchar(100)")]
        [Required]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a descrição do chamado.
        /// </summary>
        /// <example>O sistema está apresentando erros ao tentar realizar determinada ação.</example>
        [Column("descricao", TypeName = "text")]
        [Required]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o status do chamado.
        /// </summary>
        /// <example>0</example> 
        [Column("status", TypeName = "varchar(20)")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Obtém ou define a prioridade do chamado.
        /// </summary>
        /// <example>3</example>
        [Column("prioridade", TypeName = "varchar(10)")]
        public PrioridadeEnum Prioridade { get; set; }

        /// <summary>
        /// Obtém ou define a categoria do chamado.
        /// </summary>
        /// <example>1</example>
        [Column("categoria", TypeName = "varchar(20)")]
        public CategoriaEnum Categoria { get; set; }

        /// <summary>
        /// Obtém ou define a data de abertura do chamado.
        /// </summary>
        /// <example>2026-03-01T17:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("criado_em", TypeName = "timestamp with time zone")]
        public DateTime DataAbertura { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Obtém ou define a data de atualização do chamado.
        /// </summary>
        /// <example>2026-03-01T17:30:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("atualizado_em", TypeName = "timestamp with time zone")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Obtém ou define a data de encerramento do chamado.
        /// </summary>
        /// <example>2026-03-01T18:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("fechado_em", TypeName = "timestamp with time zone")]
        public DateTime? DataEncerramento { get; set; }

        /// <summary>
        /// Obtém ou define a data e hora limite para atendimento do SLA.
        /// </summary>
        /// <example>2026-03-01T21:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("sla_prazo", TypeName = "timestamp with time zone")]
        public DateTime? SlaPrazo { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Chamado"/>.
        /// </summary>
        public Chamado() { }
        
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Chamado"/> com os parâmetros especificados.
        /// </summary>
        /// <param name="idCliente">ID do cliente ao qual o chamado pertence.</param>
        /// <param name="idEmpresa">ID da empresa à qual o chamado pertence.</param>
        /// <param name="idProduto">ID do produto ao qual o chamado pertence.</param>
        /// <param name="idColaborador">ID do colaborador responsável pelo chamado.</param>
        /// <param name="titulo">Título do chamado.</param>
        /// <param name="descricao">Descrição do chamado.</param>
        /// <param name="status">Status do chamado.</param>
        public Chamado(long idCliente, long idEmpresa, long idProduto, long idColaborador, string titulo, string descricao, StatusEnum status)
        {
            IdCliente = idCliente;
            IdEmpresa = idEmpresa;
            IdProduto = idProduto;
            IdColaborador = idColaborador;
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
        }
    }
}
