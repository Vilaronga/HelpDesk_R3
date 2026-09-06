using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        /// Obtém ou define o conjunto de entidades SlaCategoria no contexto do banco de dados.
        /// </summary>
        public DbSet<SlaCategoria> SlaCategoria { get; set;}

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
            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataCadastro)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Chamado>()
                .Property(c => c.CodigoPublico)
                .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Chamado>()
                .HasIndex(c => c.CodigoPublico)
                .IsUnique();
            modelBuilder.Entity<Chamado>()
                .Property(c => c.Prioridade)
                .HasConversion<string>(); 
            modelBuilder.Entity<Chamado>()
                .Property(c => c.Categoria)
                .HasConversion<string>(); 
            modelBuilder.Entity<Chamado>()
                .Property(c => c.Status)
                .HasConversion<string>(); 
            modelBuilder.Entity<Chamado>()
                .Property(c => c.DataAbertura)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.DataCadastroEmpresa)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<SlaCategoria>()
                .Property(s => s.Prioridade)
                .HasConversion<string>();
            modelBuilder.Entity<SlaCategoria>()
                .Property(s => s.Categoria)
                .HasConversion<string>();
            modelBuilder.Entity<SlaCategoria>()
                .HasIndex(s => new { s.IdProduto, s.Categoria, s.Prioridade })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
