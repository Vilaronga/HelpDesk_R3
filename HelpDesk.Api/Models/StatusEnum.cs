namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Enumeração que representa os possíveis status de um chamado no sistema de Help Desk.
    /// </summary>
    public enum StatusEnum
    {
        /// <summary>
        /// Indica que o chamado está aberto e aguardando atendimento.
        /// </summary>
        /// <example>1</example>
        Aberto = 1,
        /// <summary>
        /// Indica que o chamado está em andamento e sendo tratado.
        /// </summary>
        /// <example>2</example>
        Pendente = 2,
        /// <summary>
        /// Indica que o chamado foi finalizado e concluído.
        /// </summary>
        /// <example>3</example>
        Finalizado = 3
    }
}