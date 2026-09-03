using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Data
{
    /// <summary>
    /// Representa o contexto do banco de dados para o sistema de Help Desk, fornecendo acesso às entidades e tabelas do banco de dados.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Inicializa uma nova instância do contexto do banco de dados com as opções especificadas.
        /// </summary>
        /// <param name="options">As opções de configuração do DbContext.</param>
        public AppDbContext(DbContextOptions options) : base(options){}
        
        /// <summary>
        /// Obtém ou define o conjunto de entidades Cliente no contexto do banco de dados.
        /// </summary>
        public DbSet<Cliente> Cliente { get; set;}

        /// <summary>
        /// Obtém ou define o conjunto de entidades Chamado no contexto do banco de dados.
        /// </summary>
        public DbSet<Chamado> Chamado { get; set;}

        /// <summary>
        /// Obtém ou define o conjunto de entidades Colaborador no contexto do banco de dados.
        /// </summary>
        public DbSet<Colaborador> Colaborador { get; set;}

        /// <summary>
        /// Obtém ou define o conjunto de entidades Produto no contexto do banco de dados.
        /// </summary>
        public DbSet<Empresa> Empresa { get; set;}

        /// <summary>
        /// Obtém ou define o conjunto de entidades Produto no contexto do banco de dados.
        /// </summary>
        public DbSet<Produto> Produto { get; set;}

        /// <summary>
        /// Obtém ou define o conjunto de entidades Empresa no contexto do banco de dados.
        /// </summary>
        /// <param name="modelBuilder">O construtor do modelo do Entity Framework.</param>
        /// <remarks>Este método é chamado pelo Entity Framework para configurar o modelo do banco de dados definindo índices como únicos.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();
            /*modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Cpf)
                .IsUnique();*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
