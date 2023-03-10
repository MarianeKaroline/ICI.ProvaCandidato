﻿// <auto-generated />
using ICI.ProvaCandidato.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICI.ProvaCandidato.Dados.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230308170928_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Noticia");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.NoticiaTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("NoticiaId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NoticiaId");

                    b.HasIndex("TagId");

                    b.ToTable("NoticiaTag");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Noticia", b =>
                {
                    b.HasOne("ICI.ProvaCandidato.Dados.Entities.Usuario", "Usuario")
                        .WithMany("Noticias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.NoticiaTag", b =>
                {
                    b.HasOne("ICI.ProvaCandidato.Dados.Entities.Noticia", "Noticia")
                        .WithMany("NoticiaTags")
                        .HasForeignKey("NoticiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICI.ProvaCandidato.Dados.Entities.Tag", "Tag")
                        .WithMany("NoticiaTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Noticia");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Noticia", b =>
                {
                    b.Navigation("NoticiaTags");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Tag", b =>
                {
                    b.Navigation("NoticiaTags");
                });

            modelBuilder.Entity("ICI.ProvaCandidato.Dados.Entities.Usuario", b =>
                {
                    b.Navigation("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
