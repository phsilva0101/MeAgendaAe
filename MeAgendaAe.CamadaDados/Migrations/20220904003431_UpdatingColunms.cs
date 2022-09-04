using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeAgendaAe.CamadaDados.Migrations
{
    public partial class UpdatingColunms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TbStatusAgendamentos",
                columns: table => new
                {
                    IdStatusAgendamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStatusAgendamentos", x => x.IdStatusAgendamento);
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
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmpresas", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_TbEmpresas_TbCidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "TbCidades",
                        principalColumn: "IdCidades",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbEmpresas_TbEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "TbEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TbCidadesIdCidades = table.Column<long>(type: "bigint", nullable: true),
                    TbEstadosIdEstado = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_TbUsuarios_TbCidades_TbCidadesIdCidades",
                        column: x => x.TbCidadesIdCidades,
                        principalTable: "TbCidades",
                        principalColumn: "IdCidades",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbUsuarios_TbEstados_TbEstadosIdEstado",
                        column: x => x.TbEstadosIdEstado,
                        principalTable: "TbEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbCliente",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    IdCidade = table.Column<long>(type: "bigint", nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    QtdVisitas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_TbCliente_TbCidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "TbCidades",
                        principalColumn: "IdCidades",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbCliente_TbEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "TbEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbCliente_TbUsuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "TbUsuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbAgendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    IdStatusAgendamento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAgendamentos", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_TbAgendamentos_TbCliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TbCliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbAgendamentos_TbEmpresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "TbEmpresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbAgendamentos_TbStatusAgendamentos_IdStatusAgendamento",
                        column: x => x.IdStatusAgendamento,
                        principalTable: "TbStatusAgendamentos",
                        principalColumn: "IdStatusAgendamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbAgendamentos_IdCliente",
                table: "TbAgendamentos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TbAgendamentos_IdEmpresa",
                table: "TbAgendamentos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TbAgendamentos_IdStatusAgendamento",
                table: "TbAgendamentos",
                column: "IdStatusAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_IdCidade",
                table: "TbCliente",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_IdEstado",
                table: "TbCliente",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_IdUsuario",
                table: "TbCliente",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_IdCidade",
                table: "TbEmpresas",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_IdEstado",
                table: "TbEmpresas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_TbPagamentos_IdFormaPagamento",
                table: "TbPagamentos",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuarios_TbCidadesIdCidades",
                table: "TbUsuarios",
                column: "TbCidadesIdCidades");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuarios_TbEstadosIdEstado",
                table: "TbUsuarios",
                column: "TbEstadosIdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAgendamentos");

            migrationBuilder.DropTable(
                name: "TbConfiguracoes");

            migrationBuilder.DropTable(
                name: "TbPagamentos");

            migrationBuilder.DropTable(
                name: "TbCliente");

            migrationBuilder.DropTable(
                name: "TbEmpresas");

            migrationBuilder.DropTable(
                name: "TbStatusAgendamentos");

            migrationBuilder.DropTable(
                name: "TbFormasPagamentos");

            migrationBuilder.DropTable(
                name: "TbUsuarios");

            migrationBuilder.DropTable(
                name: "TbCidades");

            migrationBuilder.DropTable(
                name: "TbEstados");
        }
    }
}
