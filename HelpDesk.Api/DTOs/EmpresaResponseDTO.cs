using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para resposta de informações de uma empresa no sistema de Help Desk.
    /// </summary>
    public class EmpresaResponseDTO
    {
        /// <summary>
        /// Nome da empresa retornada na resposta.
        /// </summary>
        public string Nome { get; set; }
    }
}