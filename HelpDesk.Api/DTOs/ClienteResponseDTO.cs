using HelpDesk.Api.Models;

namespace HelpDesk.Api.DTOs
{
    /// <summary>
    /// DTO de resposta para representar os dados de um cliente no sistema de Help Desk.
    /// </summary>
    public class ClienteResponseDTO
    {
        /// <summary>
        /// Obtém ou define o identificador único do cliente.
        /// </summary>
        /// <example>1</example>
        public long Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        /// <example>João da Silva</example>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o e-mail do cliente.
        /// </summary>
        /// <example>joao.silva@exemplo.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define o telefone do cliente.
        /// </summary>
        /// <example>11999999999</example>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Obtém ou define os dados detalhados da empresa associada ao cliente.
        /// </summary>
        public Empresa Empresa { get; set; } // Removido o <example> incorreto para evitar quebra no Swagger JSON
    }
}
