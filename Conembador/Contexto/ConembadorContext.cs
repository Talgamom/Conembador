using Conembador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace Conembador.Contexto
{
    public class ConembadorContext : DbContext
    {
        public ConembadorContext(DbContextOptions<ConembadorContext> options) : base(options)
        {
        }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Itens> Itens { get; set; }

        /*passado a usar o appsetting.json e o program.cs para configurar o banco.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=teste;Integrated Security=True;TrustServerCertificate=true;");
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquivo>().ToTable("arquivo");
            modelBuilder.Entity<Itens>().ToTable("item");

            modelBuilder.Entity<Arquivo>().HasKey(a => a.id_arquivo);
            modelBuilder.Entity<Itens>().HasKey(a => a.id_item);

            modelBuilder.Entity<Arquivo>()
                .HasMany(a => a.ItensArquivo)
                .WithOne()
                .HasForeignKey(i => i.id_arquivo);
        }
    }
}
