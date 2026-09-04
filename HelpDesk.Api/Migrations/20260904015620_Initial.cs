using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelpDesk.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colaborador",
                columns: table => new
                {
                    id_colaborador = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_colaborador = table.Column<string>(type: "varchar(100)", nullable: false),
                    email_colaborador = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpf_colaborador = table.Column<string>(type: "varchar(11)", nullable: false),
                    telefone_colaborador = table.Column<string>(type: "varchar(11)", nullable: true),
                    data_cadastro_colaborador = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_atualizacao_colaborador = table.Column<DateTime>(type: "timestamp", nullable: false),
                    colaborador_ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaborador", x => x.id_colaborador);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id_empresa = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_empresa = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro_empresa = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id_empresa);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id_produto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_produto = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro_produto = table.Column<DateTime>(type: "timestamp", nullable: false),
                    produto_ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id_produto);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_cliente = table.Column<string>(type: "varchar(100)", nullable: false),
                    email_cliente = table.Column<string>(type: "varchar(100)", nullable: false),
                    telefone_cliente = table.Column<string>(type: "varchar(11)", nullable: true),
                    fk_id_empresa_cliente = table.Column<long>(type: "bigint", nullable: false),
                    data_cadastro_cliente = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                    table.ForeignKey(
                        name: "FK_cliente_empresa_fk_id_empresa_cliente",
                        column: x => x.fk_id_empresa_cliente,
                        principalTable: "empresa",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chamado",
                columns: table => new
                {
                    id_chamado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_id_autor_chamado = table.Column<long>(type: "bigint", nullable: false),
                    fk_id_empresa_chamado = table.Column<long>(type: "bigint", nullable: false),
                    fk_id_produto_chamado = table.Column<long>(type: "bigint", nullable: false),
                    fk_id_colaborador_chamado = table.Column<long>(type: "bigint", nullable: false),
                    titulo_chamado = table.Column<string>(type: "varchar(100)", nullable: false),
                    descricao_chamado = table.Column<string>(type: "text", nullable: false),
                    status_chamado = table.Column<string>(type: "varchar(10)", nullable: false),
                    data_abertura_chamado = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_atualizacao_chamado = table.Column<DateTime>(type: "timestamp", nullable: false),
                    data_encerramento_chamado = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamado", x => x.id_chamado);
                    table.ForeignKey(
                        name: "FK_chamado_cliente_fk_id_autor_chamado",
                        column: x => x.fk_id_autor_chamado,
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_colaborador_fk_id_colaborador_chamado",
                        column: x => x.fk_id_colaborador_chamado,
                        principalTable: "colaborador",
                        principalColumn: "id_colaborador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_empresa_fk_id_empresa_chamado",
                        column: x => x.fk_id_empresa_chamado,
                        principalTable: "empresa",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_produto_fk_id_produto_chamado",
                        column: x => x.fk_id_produto_chamado,
                        principalTable: "produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamado_fk_id_autor_chamado",
                table: "chamado",
                column: "fk_id_autor_chamado");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_fk_id_colaborador_chamado",
                table: "chamado",
                column: "fk_id_colaborador_chamado");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_fk_id_empresa_chamado",
                table: "chamado",
                column: "fk_id_empresa_chamado");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_fk_id_produto_chamado",
                table: "chamado",
                column: "fk_id_produto_chamado");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_email_cliente",
                table: "cliente",
                column: "email_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_fk_id_empresa_cliente",
                table: "cliente",
                column: "fk_id_empresa_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamado");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "colaborador");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "empresa");
        }
    }
}
