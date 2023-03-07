﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewBook.Data.Context;

#nullable disable

namespace NewBook.Data.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20230125161141_add-livro")]
    partial class addlivro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NewBook.Domain.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("LivroCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<string>("Resumo")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Sumario")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("TipoLivroId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Livro");
                });
#pragma warning restore 612, 618
        }
    }
}
