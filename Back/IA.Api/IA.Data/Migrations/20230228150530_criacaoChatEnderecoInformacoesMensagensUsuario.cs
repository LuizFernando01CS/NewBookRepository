using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA.Data.Migrations
{
    /// <inheritdoc />
    public partial class criacaoChatEnderecoInformacoesMensagensUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroCasa = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InformacoesAdicionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LivrosCriados = table.Column<ulong>(type: "bit", nullable: false),
                    FrequenciaEscrita = table.Column<int>(type: "int", nullable: false),
                    JaEscreveu = table.Column<ulong>(type: "bit", nullable: false),
                    GostosLivroExistenteId = table.Column<int>(type: "int", nullable: false),
                    LidosLivrosExistenteId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesAdicionais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LivrosExistentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Resumo = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sumario = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeLivroCompleto = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosExistentes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InformacoesPessoais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeAbreviado = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeCompleto = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNPJ = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroTelefone1 = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefone2 = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<DateTime>(type: "datetime", nullable: false),
                    InformacoesAdicionaisId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesPessoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacoesPessoais_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformacoesPessoais_InformacoesAdicionais_InformacoesAdicion~",
                        column: x => x.InformacoesAdicionaisId,
                        principalTable: "InformacoesAdicionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacoesPessoaisID = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_InformacoesPessoais_InformacoesPessoaisID",
                        column: x => x.InformacoesPessoaisID,
                        principalTable: "InformacoesPessoais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatIA_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mensagem = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoMensagem = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    ChatIAId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_ChatIA_ChatIAId",
                        column: x => x.ChatIAId,
                        principalTable: "ChatIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MensagensNaoEntendidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MensagensId = table.Column<int>(type: "int", nullable: false),
                    MensagemRecebida = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusEntendimento = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensNaoEntendidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagensNaoEntendidas_Mensagens_MensagensId",
                        column: x => x.MensagensId,
                        principalTable: "Mensagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ChatIA_UsuarioId",
                table: "ChatIA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPessoais_EnderecoId",
                table: "InformacoesPessoais",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPessoais_InformacoesAdicionaisId",
                table: "InformacoesPessoais",
                column: "InformacoesAdicionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_ChatIAId",
                table: "Mensagens",
                column: "ChatIAId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensNaoEntendidas_MensagensId",
                table: "MensagensNaoEntendidas",
                column: "MensagensId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_InformacoesPessoaisID",
                table: "Usuario",
                column: "InformacoesPessoaisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrosExistentes");

            migrationBuilder.DropTable(
                name: "MensagensNaoEntendidas");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "ChatIA");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "InformacoesPessoais");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "InformacoesAdicionais");
        }
    }
}
