﻿// <auto-generated />
using Conembador.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conembador.Migrations
{
    [DbContext(typeof(ConembadorContext))]
    [Migration("20240516001404_CorrigiDescricaoItem")]
    partial class CorrigiDescricaoItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Conembador.Models.Arquivo", b =>
                {
                    b.Property<int>("id_arquivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_arquivo"));

                    b.Property<string>("NomeEdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Versao")
                        .HasColumnType("float");

                    b.HasKey("id_arquivo");

                    b.ToTable("arquivo", (string)null);
                });

            modelBuilder.Entity("Conembador.Models.Itens", b =>
                {
                    b.Property<int>("id_item")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_item"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fim")
                        .HasColumnType("int");

                    b.Property<int>("Inicio")
                        .HasColumnType("int");

                    b.Property<int>("id_arquivo")
                        .HasColumnType("int");

                    b.HasKey("id_item");

                    b.HasIndex("id_arquivo");

                    b.ToTable("item", (string)null);
                });

            modelBuilder.Entity("Conembador.Models.Itens", b =>
                {
                    b.HasOne("Conembador.Models.Arquivo", null)
                        .WithMany("ItensArquivo")
                        .HasForeignKey("id_arquivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Conembador.Models.Arquivo", b =>
                {
                    b.Navigation("ItensArquivo");
                });
#pragma warning restore 612, 618
        }
    }
}
