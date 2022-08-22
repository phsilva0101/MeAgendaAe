using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeAgendaAe.CamadaDados.Migrations
{
    public partial class CREATE_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAgendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAgendamentos", x => x.IdAgendamento);
                });

            migrationBuilder.CreateTable(
                name: "TbCidades",
                columns: table => new
                {
                    IdCidades = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCidades", x => x.IdCidades);
                });

            migrationBuilder.CreateTable(
                name: "TbConfiguracoes",
                columns: table => new
                {
                    IdConfiguracao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbConfiguracoes", x => x.IdConfiguracao);
                });

            migrationBuilder.CreateTable(
                name: "TbEstados",
                columns: table => new
                {
                    IdEstado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEstados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "TbFormasPagamentos",
                columns: table => new
                {
                    IdFormasPagamentos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoFormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFormasPagamentos", x => x.IdFormasPagamentos);
                });

            migrationBuilder.CreateTable(
                name: "TbEmpresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCidade = table.Column<long>(type: "bigint", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    TbAgendamentosIdAgendamento = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmpresas", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_TbEmpresas_TbAgendamentos_TbAgendamentosIdAgendamento",
                        column: x => x.TbAgendamentosIdAgendamento,
                        principalTable: "TbAgendamentos",
                        principalColumn: "IdAgendamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbEmpresas_TbCidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "TbCidades",
                        principalColumn: "IdCidades",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbEmpresas_TbEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "TbEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdCidade = table.Column<long>(type: "bigint", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_TbUsuarios_TbCidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "TbCidades",
                        principalColumn: "IdCidades",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbUsuarios_TbEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "TbEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbPagamentos",
                columns: table => new
                {
                    IdPagamentos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Parcelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPagamentos", x => x.IdPagamentos);
                    table.ForeignKey(
                        name: "FK_TbPagamentos_TbFormasPagamentos_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "TbFormasPagamentos",
                        principalColumn: "IdFormasPagamentos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_IdCidade",
                table: "TbEmpresas",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_IdEstado",
                table: "TbEmpresas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_TbAgendamentosIdAgendamento",
                table: "TbEmpresas",
                column: "TbAgendamentosIdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_TbPagamentos_IdFormaPagamento",
                table: "TbPagamentos",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuarios_IdCidade",
                table: "TbUsuarios",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuarios_IdEstado",
                table: "TbUsuarios",
                column: "IdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbConfiguracoes");

            migrationBuilder.DropTable(
                name: "TbEmpresas");

            migrationBuilder.DropTable(
                name: "TbPagamentos");

            migrationBuilder.DropTable(
                name: "TbUsuarios");

            migrationBuilder.DropTable(
                name: "TbAgendamentos");

            migrationBuilder.DropTable(
                name: "TbFormasPagamentos");

            migrationBuilder.DropTable(
                name: "TbCidades");

            migrationBuilder.DropTable(
                name: "TbEstados");
        }
    }
}
