using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }
    }
}