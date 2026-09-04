using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para requisição de criação de uma nova empresa no sistema de Help Desk.
    /// </summary>
    public class EmpresaRequestDTO
    {
        /// <summary>
        /// Nome da empresa a ser criada.
        /// </summary>
        public string Nome { get; set; }
    }
}