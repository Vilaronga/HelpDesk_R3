using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Data
{
    /**
     * Esta classe representa o contexto do banco de dados da aplicação, ela herda a classe DbContext.
     */
    public class AppDbContext : DbContext
    {
        //Construtor da classe AppDbContext que recebe as opções de configuração do DbContext.
        public AppDbContext(DbContextOptions options) : base(options){}
        
        public DbSet<Cliente> Cliente { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Cpf)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
