using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para requisição de informações de um produto no sistema de Help Desk.
    /// </summary>
    public class ProdutoRequestDTO
    {
        /// <summary>
        /// Nome do produto enviado na requisição.
        /// </summary>
        public string NomeProduto { get; set; }
    }
}