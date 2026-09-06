namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Enumeração que representa os níveis de prioridade de um chamado no sistema de Help Desk.
    /// </summary>
    public enum PrioridadeEnum
    {
        /// <summary>
        /// Indica que o chamado possui prioridade baixa e não requer atenção imediata.
        /// </summary>
        Baixa = 1,

        /// <summary>
        /// Indica que o chamado possui prioridade média e deve ser tratado em tempo hábil.
        /// </summary>
        Media = 2,

        /// <summary>
        /// Indica que o chamado possui prioridade alta e requer atenção rápida.
        /// </summary>
        Alta = 3,

        /// <summary>
        /// Indica que o chamado possui prioridade urgente e deve ser tratado imediatamente.
        /// </summary>
        Urgente = 4
    }
}