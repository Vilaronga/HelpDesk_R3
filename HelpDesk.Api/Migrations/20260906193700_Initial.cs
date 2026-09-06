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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(11)", nullable: true),
                    data_cadastro_colaborador = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao_colaborador = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    colaborador_ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaborador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro_empresa = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro_produto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao_produto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    grupo_empresa_id = table.Column<long>(type: "bigint", nullable: false),
                    data_cadastro_cliente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_empresa_grupo_empresa_id",
                        column: x => x.grupo_empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sla_categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    produto_id = table.Column<long>(type: "bigint", nullable: false),
                    categoria = table.Column<string>(type: "varchar(20)", nullable: false),
                    prioridade = table.Column<string>(type: "varchar(20)", nullable: false),
                    tempo_resposta = table.Column<TimeSpan>(type: "interval", nullable: false),
                    tempo_resolucao = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sla_categorias", x => x.id);
                    table.ForeignKey(
                        name: "FK_sla_categorias_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chamado",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_publico = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    cliente_id = table.Column<long>(type: "bigint", nullable: true),
                    grupo_empresa_id = table.Column<long>(type: "bigint", nullable: false),
                    produto_id = table.Column<long>(type: "bigint", nullable: false),
                    colaborador_id = table.Column<long>(type: "bigint", nullable: true),
                    titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    prioridade = table.Column<string>(type: "varchar(10)", nullable: false),
                    categoria = table.Column<string>(type: "varchar(20)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fechado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sla_prazo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamado", x => x.id);
                    table.ForeignKey(
                        name: "FK_chamado_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_chamado_colaborador_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "colaborador",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_chamado_empresa_grupo_empresa_id",
                        column: x => x.grupo_empresa_id,
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cliente_id",
                table: "chamado",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_codigo_publico",
                table: "chamado",
                column: "codigo_publico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chamado_colaborador_id",
                table: "chamado",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_grupo_empresa_id",
                table: "chamado",
                column: "grupo_empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_produto_id",
                table: "chamado",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_email",
                table: "cliente",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_grupo_empresa_id",
                table: "cliente",
                column: "grupo_empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_sla_categorias_produto_id_categoria_prioridade",
                table: "sla_categorias",
                columns: new[] { "produto_id", "categoria", "prioridade" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamado");

            migrationBuilder.DropTable(
                name: "sla_categorias");

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
