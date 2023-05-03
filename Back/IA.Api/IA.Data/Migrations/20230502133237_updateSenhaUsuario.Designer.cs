﻿// <auto-generated />
using System;
using IA.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IA.Data.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20230502133237_updateSenhaUsuario")]
    partial class updateSenhaUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IA.Domain.Entities.ChatIA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ChatIA");
                });

            modelBuilder.Entity("IA.Domain.Entities.ChaveValor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("ChaveValor");
                });

            modelBuilder.Entity("IA.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumeroCasa")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("varchar(50)");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<string>("Rua")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("IA.Domain.Entities.InformacoesAdicionais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<int>("FrequenciaEscrita")
                        .HasColumnType("int");

                    b.Property<int?>("GostosLivroExistenteId")
                        .HasColumnType("int");

                    b.Property<ulong>("JaEscreveu")
                        .HasColumnType("bit");

                    b.Property<int?>("LidosLivrosExistenteId")
                        .HasColumnType("int");

                    b.Property<ulong>("LivrosCriados")
                        .HasColumnType("bit");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("InformacoesAdicionais");
                });

            modelBuilder.Entity("IA.Domain.Entities.InformacoesPessoais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Idade")
                        .HasColumnType("datetime");

                    b.Property<string>("NomeAbreviado")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumeroTelefone1")
                        .HasColumnType("int");

                    b.Property<int>("NumeroTelefone2")
                        .HasColumnType("int");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("InformacoesPessoais");
                });

            modelBuilder.Entity("IA.Domain.Entities.InteligenciaArtificial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorChatIA")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CorMensagemIA")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CorMensagemUsuario")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<ulong>("Estilizado")
                        .HasColumnType("bit");

                    b.Property<string>("NomeIA")
                        .HasColumnType("varchar(200)");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<int>("TipoEstilizado")
                        .HasColumnType("int");

                    b.Property<int>("TipoVoz")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("InteligenciaArtificial");
                });

            modelBuilder.Entity("IA.Domain.Entities.Livro", b =>
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

                    b.Property<int?>("TipoLivroId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("IA.Domain.Entities.LivrosExistentes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Genero")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeLivroCompleto")
                        .HasColumnType("varchar(100)");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<string>("Resumo")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Sumario")
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("LivrosExistentes");
                });

            modelBuilder.Entity("IA.Domain.Entities.Mensagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ChatIAId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("OrigemMensagem")
                        .HasColumnType("int");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<int>("TipoMensagem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatIAId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("IA.Domain.Entities.MensagensNaoEntendidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("MensagemRecebida")
                        .HasColumnType("varchar(1000)");

                    b.Property<int?>("MensagensId")
                        .HasColumnType("int");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<int>("StatusEntendimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MensagensId");

                    b.ToTable("MensagensNaoEntendidas");
                });

            modelBuilder.Entity("IA.Domain.Entities.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<int>("PermissaoFone")
                        .HasColumnType("int");

                    b.Property<int>("PermissaoMicrofone")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("IA.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("CreateAuthGoogle")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("EnderecoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(1000)");

                    b.Property<int?>("InformacoesAdicionaisId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("InformacoesPessoaisID")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MetodoAcesso")
                        .HasColumnType("varchar(50)");

                    b.Property<ulong>("PeloSite")
                        .HasColumnType("bit");

                    b.Property<string>("ProvedorId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("InformacoesAdicionaisId");

                    b.HasIndex("InformacoesPessoaisID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.ChatIA", b =>
                {
                    b.HasOne("IA.Domain.Entities.Usuario", "Usuario")
                        .WithMany("ChatIA")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.InteligenciaArtificial", b =>
                {
                    b.HasOne("IA.Domain.Entities.Usuario", "Usuario")
                        .WithMany("InteligenciaArtificial")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.Mensagens", b =>
                {
                    b.HasOne("IA.Domain.Entities.ChatIA", "ChatIA")
                        .WithMany("Mensagens")
                        .HasForeignKey("ChatIAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatIA");
                });

            modelBuilder.Entity("IA.Domain.Entities.MensagensNaoEntendidas", b =>
                {
                    b.HasOne("IA.Domain.Entities.Mensagens", "Mensagens")
                        .WithMany("MensagensNaoEntendidas")
                        .HasForeignKey("MensagensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("IA.Domain.Entities.Permissao", b =>
                {
                    b.HasOne("IA.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Permissao")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("IA.Domain.Entities.Endereco", "Endereco")
                        .WithMany("Usuario")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IA.Domain.Entities.InformacoesAdicionais", "InformacoesAdicionais")
                        .WithMany("Usuario")
                        .HasForeignKey("InformacoesAdicionaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IA.Domain.Entities.InformacoesPessoais", "InformacoesPessoais")
                        .WithMany("Usuario")
                        .HasForeignKey("InformacoesPessoaisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("InformacoesAdicionais");

                    b.Navigation("InformacoesPessoais");
                });

            modelBuilder.Entity("IA.Domain.Entities.ChatIA", b =>
                {
                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("IA.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.InformacoesAdicionais", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.InformacoesPessoais", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IA.Domain.Entities.Mensagens", b =>
                {
                    b.Navigation("MensagensNaoEntendidas");
                });

            modelBuilder.Entity("IA.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("ChatIA");

                    b.Navigation("InteligenciaArtificial");

                    b.Navigation("Permissao");
                });
#pragma warning restore 612, 618
        }
    }
}
