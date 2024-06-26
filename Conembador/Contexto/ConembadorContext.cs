﻿using Conembador.Models;
using Microsoft.EntityFrameworkCore;

namespace Conembador.Contexto
{
    public class ConembadorContext : DbContext
    {
        public ConembadorContext(DbContextOptions<ConembadorContext> options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Itens> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquivo>().ToTable("arquivo");
            modelBuilder.Entity<Itens>().ToTable("item");

            modelBuilder.Entity<Arquivo>().HasKey(a => a.id_arquivo);
            modelBuilder.Entity<Itens>().HasKey(i => i.id_item);

            modelBuilder.Entity<Arquivo>()
                .HasMany(a => a.ItensArquivo)
                .WithOne()
                .HasForeignKey(i => i.id_arquivo);
        }
    }
}
