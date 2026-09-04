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
        [Column("id_chamado")]
        public long Id { get; set; }

        /// <summary>
        /// Obtém ou define o ID do cliente autor do chamado.
        /// </summary>
        /// <example>1</example>
        [Column("fk_id_autor_chamado")]
        public long IdCliente { get; set; }

        /// <summary>
        /// Propriedade de navegação para o cliente que abriu o chamado.
        /// </summary>
        [ForeignKey("IdCliente")]
        public Cliente Autor { get; set; }

        /// <summary>
        /// Obtém ou define o ID da empresa associada.
        /// </summary>
        /// <example>1</example>
        [Column("fk_id_empresa_chamado")]
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
        [Column("fk_id_produto_chamado")]
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
        [Column("fk_id_colaborador_chamado")]
        public long IdColaborador { get; set; }

        /// <summary>
        /// Propriedade de navegação para o colaborador responsável.
        /// </summary>
        [ForeignKey("IdColaborador")]
        public Colaborador ColaboradorResponsavel { get; set; }

        /// <summary>
        /// Obtém ou define o título do chamado.
        /// </summary>
        /// <example>Problema com o sistema</example>
        [Column("titulo_chamado", TypeName = "varchar(100)")]
        [Required]
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define a descrição do chamado.
        /// </summary>
        /// <example>O sistema está apresentando erros ao tentar realizar determinada ação.</example>
        [Column("descricao_chamado", TypeName = "text")]
        [Required]
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o status do chamado.
        /// </summary>
        /// <example>0</example> 
        [Column("status_chamado", TypeName = "varchar(10)")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Obtém ou define a data de abertura do chamado.
        /// </summary>
        /// <example>2026-03-01T17:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_abertura_chamado", TypeName = "timestamp with time zone")]
        public DateTime DataAbertura { get; set; }

        /// <summary>
        /// Obtém ou define a data de atualização do chamado.
        /// </summary>
        /// <example>2026-03-01T17:30:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_atualizacao_chamado", TypeName = "timestamp with time zone")]
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Obtém ou define a data de encerramento do chamado.
        /// </summary>
        /// <example>2026-03-01T18:00:00Z</example>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_encerramento_chamado", TypeName = "timestamp with time zone")]
        public DateTime? DataEncerramento { get; set; }

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
        /// <param name="dataAbertura">Data de abertura do chamado.</param>
        public Chamado(long idCliente, long idEmpresa, long idProduto, long idColaborador, string titulo, string descricao, StatusEnum status, DateTime dataAbertura)
        {
            IdCliente = idCliente;
            IdEmpresa = idEmpresa;
            IdProduto = idProduto;
            IdColaborador = idColaborador;
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            DataAbertura = dataAbertura;
            DataAtualizacao = dataAbertura;
        }
    }
}
