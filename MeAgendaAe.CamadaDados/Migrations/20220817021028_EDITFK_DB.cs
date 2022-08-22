using Microsoft.EntityFrameworkCore.Migrations;

namespace MeAgendaAe.CamadaDados.Migrations
{
    public partial class EDITFK_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbEmpresas_TbAgendamentos_TbAgendamentosIdAgendamento",
                table: "TbEmpresas");

            migrationBuilder.DropIndex(
                name: "IX_TbEmpresas_TbAgendamentosIdAgendamento",
                table: "TbEmpresas");

            migrationBuilder.DropColumn(
                name: "TbAgendamentosIdAgendamento",
                table: "TbEmpresas");

            migrationBuilder.CreateIndex(
                name: "IX_TbAgendamentos_IdEmpresa",
                table: "TbAgendamentos",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAgendamentos_TbEmpresas_IdEmpresa",
                table: "TbAgendamentos",
                column: "IdEmpresa",
                principalTable: "TbEmpresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAgendamentos_TbEmpresas_IdEmpresa",
                table: "TbAgendamentos");

            migrationBuilder.DropIndex(
                name: "IX_TbAgendamentos_IdEmpresa",
                table: "TbAgendamentos");

            migrationBuilder.AddColumn<long>(
                name: "TbAgendamentosIdAgendamento",
                table: "TbEmpresas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbEmpresas_TbAgendamentosIdAgendamento",
                table: "TbEmpresas",
                column: "TbAgendamentosIdAgendamento");

            migrationBuilder.AddForeignKey(
                name: "FK_TbEmpresas_TbAgendamentos_TbAgendamentosIdAgendamento",
                table: "TbEmpresas",
                column: "TbAgendamentosIdAgendamento",
                principalTable: "TbAgendamentos",
                principalColumn: "IdAgendamento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
