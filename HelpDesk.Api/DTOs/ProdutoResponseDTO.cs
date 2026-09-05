using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para resposta de informações de um produto no sistema de Help Desk.
    /// </summary>
    public class ProdutoResponseDTO
    {
        /// <summary>
        /// Nome do produto retornado na resposta.
        /// </summary>
        public string NomeProduto { get; set; }
    }
}