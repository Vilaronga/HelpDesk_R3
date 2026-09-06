namespace HelpDesk.Api.Models
{
    /// <summary>
    /// Enumeração que representa as categorias de um chamado no sistema de Help Desk.
    /// </summary>
    public enum CategoriaEnum
    {
        /// <summary>
        /// Indica que o chamado está relacionado a um bug.
        /// </summary>
        Bugs = 1,

        /// <summary>
        /// Indica que o chamado está relacionado a intercace (visual).
        /// </summary>
        Interface = 2,

        /// <summary>
        /// Indica que o chamado está relacionado a lógica do programa.
        /// </summary>
        Logica = 3
    }
}