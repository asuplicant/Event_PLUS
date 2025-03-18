﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Events_PLUS.Context;

#nullable disable

namespace Events_PLUS.Migrations
{
    [DbContext(typeof(Events_Plus_Context))]
    partial class Events_Plus_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Events_PLUS.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("IdComentarioEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdComentarioEvento");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ComentarioEvento");
                });

            modelBuilder.Entity("Events_PLUS.Domains.Eventos", b =>
                {
                    b.Property<Guid>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("IdInstituicoes")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTipoEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdEvento");

                    b.HasIndex("IdInstituicoes");

                    b.HasIndex("IdTipoEvento");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Events_PLUS.Domains.Instituicoes", b =>
                {
                    b.Property<Guid>("IdInstituicoes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Endereço")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdInstituicoes");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("Events_PLUS.Domains.PresencasEventos", b =>
                {
                    b.Property<Guid>("IdPresenca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Presenca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdPresenca");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PresencaEventos");
                });

            modelBuilder.Entity("Events_PLUS.Domains.TiposEventos", b =>
                {
                    b.Property<Guid>("IdTipoEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdTipoEvento");

                    b.ToTable("TiposEventos");
                });

            modelBuilder.Entity("Events_PLUS.Domains.TiposUsuarios", b =>
                {
                    b.Property<Guid>("TipoUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TipoUsuarioID");

                    b.ToTable("TiposUsuarios");
                });

            modelBuilder.Entity("Events_PLUS.Domains.Usuarios", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senhas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Events_PLUS.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Events_PLUS.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Events_PLUS.Domains.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Events_PLUS.Domains.Eventos", b =>
                {
                    b.HasOne("Events_PLUS.Domains.Instituicoes", "Instituicao")
                        .WithMany()
                        .HasForeignKey("IdInstituicoes");

                    b.HasOne("Events_PLUS.Domains.TiposEventos", "TipoEvento")
                        .WithMany()
                        .HasForeignKey("IdTipoEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");

                    b.Navigation("TipoEvento");
                });

            modelBuilder.Entity("Events_PLUS.Domains.PresencasEventos", b =>
                {
                    b.HasOne("Events_PLUS.Domains.Eventos", "Evento")
                        .WithMany()
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Events_PLUS.Domains.Usuarios", "IdUsuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("IdUsuarios");
                });

            modelBuilder.Entity("Events_PLUS.Domains.Usuarios", b =>
                {
                    b.HasOne("Events_PLUS.Domains.TiposUsuarios", "TiposUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
