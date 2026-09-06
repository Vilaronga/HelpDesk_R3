using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para resposta de Regras criadas no sistema de Help Desk.
    /// </summary>
    public class SlaCategoriaResponseDTO
    {
        /// <summary>
        /// Obtém o id da Regra Sla.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém o id do Produto da Regra Sla.
        /// </summary>
        public long IdProduto { get; set; }

        /// <summary>
        /// Obtém o nome do Produto da Regra Sla.
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty; 

        /// <summary>
        /// Obtém o id da Categoria da Regra Sla.
        /// </summary>
        public string Categoria { get; set; } = string.Empty;  

        /// <summary>
        /// Obtém a Prioridade da Regra Sla.
        /// </summary> 
        public string Prioridade { get; set; } = string.Empty; 

        /// <summary>
        /// Obtém o Tempo de Resposta da Regra Sla.
        /// </summary> 
        public string TempoResposta { get; set; } = string.Empty;  

        /// <summary>
        /// Obtém o Tempo de Resolução da Regra Sla.
        /// </summary>
        public string TempoResolucao { get; set; } = string.Empty;
    }
}