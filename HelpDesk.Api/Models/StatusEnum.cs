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
        Aberto = 1,
        
        /// <summary>
        /// Indica que o chamado está em andamento, sendo tratado por um colaborador.
        /// </summary>
        EmAndamento = 2,
        
        /// <summary>
        /// Indica que o chamado está aguardando uma resposta ou ação do cliente.
        /// </summary>
        AguardandoCliente = 3,

        /// <summary>
        /// Indica que o chamado foi resolvido e não requer mais ações.
        /// </summary>
        Resolvido = 4,

        /// <summary>
        /// Indica que o chamado foi fechado e não pode mais ser reaberto.
        /// </summary>
        Fechado = 5
    }
}