using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para resposta de informações de uma Chamado no sistema de Help Desk.
    /// </summary>
    public class ChamadoResponseDTO
    {   
        /// <summary>
        /// Obtém o código público compartihável do chamado.
        /// </summary>
        public Guid CodigoPublico { get; set; }

        /// <summary>
        /// Obtém o título do chamado.
        /// </summary>
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Obtém a descrição do chamado.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Obtém o status do chamado.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Obtém a prioridade do chamado.
        /// </summary>
        public string Prioridade { get; set; } = string.Empty;

        /// <summary>
        /// Obtém a descrição do chamado.
        /// </summary>
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// Obtém a data de abertura do chamado.
        /// </summary>
        public DateTime DataAbertura { get; set; }

        /// <summary>
        /// Obtém a data da última atualização do chamado.
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Obtém a data de encerramento do chamado. Pode vir nulo.
        /// </summary>
        public DateTime? DataEncerramento { get; set; }

        /// <summary>
        /// Obtém o prazo de resolução total do chamado.
        /// </summary>
        public DateTime? SlaPrazo { get; set; }

        /// <summary>
        /// Obtém o nome do cliente do chamado.
        /// </summary>
        public string NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// Obtém o nome do Grupo Empresa do chamado.
        /// </summary>
        public string NomeEmpresa { get; set; } = string.Empty;

        /// <summary>
        /// Obtém o nome do Produto do chamado.
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Obtém o nome do Colaborador Responsável pelo chamado.
        /// </summary>
        public string NomeColaboradorResponsavel { get; set; } = string.Empty;
    }
}