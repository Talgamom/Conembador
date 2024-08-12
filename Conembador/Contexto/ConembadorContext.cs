using Conembador.Models;
using Microsoft.EntityFrameworkCore;

namespace Conembador.Contexto
{
    public class ConembadorContext : DbContext
    {
        public ConembadorContext(DbContextOptions<ConembadorContext> options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquivo>().ToTable("arquivo");
            modelBuilder.Entity<Item>().ToTable("item");

            modelBuilder.Entity<Arquivo>().HasKey(a => a.Id_arquivo);
            modelBuilder.Entity<Item>().HasKey(i => i.Id_item);

            modelBuilder.Entity<Arquivo>()
                .HasMany(a => a.ItensArquivo)
                .WithOne()
                .HasForeignKey(i => i.Id_arquivo);
        }

    }
}
