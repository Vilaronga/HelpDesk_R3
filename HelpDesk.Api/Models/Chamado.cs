using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace HelpDesk.Api.Models
{   
    /// <summary>
    /// Esta classe representa um Chamado no banco de dados.
    /// </summary>
    [Table("chamado")]
    public class Chamado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_chamado")]
        public long Id { get; set; }

        [ForeignKey("Id")]
        [Column("fk_id_autor_chamado")]
        [Required]
        public Cliente IdAutor { get; set; }

        [ForeignKey("IdEmpresa")]
        [Column("fk_id_empresa_chamado")]
        [Required]
        public Empresa IdEmpresa { get; set; }

        [ForeignKey("IdProduto")]
        [Column("fk_id_produto_chamado")]
        [Required]
        public Produto IdProduto { get; set; }

        [Column("titulo_chamado", TypeName = "varchar(100)")]
        [Required]
        public string Titulo { get; set; }

        [Column("descricao_chamado", TypeName = "text")]
        [Required]
        public string Descricao { get; set; }

        [Column("status_chamado", TypeName = "varchar(10)")]
        public StatusEnum Status { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_abertura_chamado", TypeName = "datetime")]
        public DateTime DataAbertura { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Column("data_encerramento_chamado", TypeName = "datetime")]
        public DateTime DataEncerramento { get; set; }

        public Chamado()
        {
            
        }

        public Chamado(Cliente idAutor, Empresa idEmpresa, Produto idProduto, string titulo, string descricao, StatusEnum status, DateTime dataAbertura)
        {
         IdAutor = idAutor;
         IdEmpresa = idEmpresa;
         IdProduto = idProduto;
         Titulo = titulo;
         Descricao = descricao;
         Status = status;
         DataAbertura = dataAbertura;
        }
    }
}