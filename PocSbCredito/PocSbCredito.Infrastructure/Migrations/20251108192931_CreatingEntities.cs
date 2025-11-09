using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocSbCredito.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_empresa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    valor_limite_credito = table.Column<decimal>(type: "TEXT", nullable: true),
                    st_registro = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_empresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_fundofidc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    saldo_disponivel = table.Column<decimal>(type: "TEXT", nullable: false),
                    rentabilidade_mensal = table.Column<decimal>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fundofidc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_investidor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    saldo_aplicado = table.Column<decimal>(type: "TEXT", nullable: false),
                    fundo_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_investidor", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_investidor_tb_fundofidc_fundo_id",
                        column: x => x.fundo_id,
                        principalTable: "tb_fundofidc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_operacaoantecipacao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    empresa_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FundoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    data_operacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    taxa_mensal = table.Column<decimal>(type: "TEXT", nullable: false),
                    valor_total_original = table.Column<decimal>(type: "TEXT", nullable: false),
                    valor_total_antecipado = table.Column<decimal>(type: "TEXT", nullable: false),
                    dias_medios = table.Column<int>(type: "INTEGER", nullable: false),
                    status_operacao = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_operacaoantecipacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_operacaoantecipacao_tb_empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "tb_empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_operacaoantecipacao_tb_fundofidc_FundoId",
                        column: x => x.FundoId,
                        principalTable: "tb_fundofidc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_recebivel",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    empresa_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    pagador = table.Column<string>(type: "TEXT", nullable: false),
                    numero_documento = table.Column<string>(type: "TEXT", nullable: true),
                    valor_original = table.Column<decimal>(type: "TEXT", nullable: false),
                    data_emissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    data_vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valor_antecipado = table.Column<decimal>(type: "TEXT", nullable: true),
                    operacao_antecipacao_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    status_recebivel = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_recebivel", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_recebivel_tb_empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "tb_empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_recebivel_tb_operacaoantecipacao_operacao_antecipacao_id",
                        column: x => x.operacao_antecipacao_id,
                        principalTable: "tb_operacaoantecipacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_investidor_fundo_id",
                table: "tb_investidor",
                column: "fundo_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_operacaoantecipacao_empresa_id",
                table: "tb_operacaoantecipacao",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_operacaoantecipacao_FundoId",
                table: "tb_operacaoantecipacao",
                column: "FundoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recebivel_empresa_id",
                table: "tb_recebivel",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recebivel_operacao_antecipacao_id",
                table: "tb_recebivel",
                column: "operacao_antecipacao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_investidor");

            migrationBuilder.DropTable(
                name: "tb_recebivel");

            migrationBuilder.DropTable(
                name: "tb_operacaoantecipacao");

            migrationBuilder.DropTable(
                name: "tb_empresa");

            migrationBuilder.DropTable(
                name: "tb_fundofidc");
        }
    }
}
