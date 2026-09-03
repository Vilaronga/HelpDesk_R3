using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO para adicionar um novo cliente ao sistema de Help Desk.
    /// </summary>
    public class AddClienteDTO
    {
        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        /// <example>João da Silva</example>
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o e-mail do cliente.
        /// </summary>
        /// <example>joao.silva@exemplo.com</example>
        [Required(ErrorMessage = "O email do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o telefone do cliente.
        /// </summary>
        /// <example>11999999999</example>
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Telefone { get; set; } = string.Empty;
        
        /// <summary>
        /// Obtém ou define o identificador único da empresa associada ao cliente.
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "A empresa do cliente é obrigatória.")]
        public long? IdEmpresa { get; set; }
    }
}
