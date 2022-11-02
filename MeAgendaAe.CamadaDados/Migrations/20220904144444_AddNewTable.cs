using Microsoft.EntityFrameworkCore.Migrations;

namespace MeAgendaAe.Dominio.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoIBGE",
                table: "TbEstados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DDD",
                table: "TbEstados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPais",
                table: "TbEstados",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "TbEstados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "IdEstado",
                table: "TbCidades",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TbPaises",
                columns: table => new
                {
                    IdPais = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPaises", x => x.IdPais);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbEstados_IdPais",
                table: "TbEstados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_TbCidades_IdEstado",
                table: "TbCidades",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_TbCidades_TbEstados_IdEstado",
                table: "TbCidades",
                column: "IdEstado",
                principalTable: "TbEstados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TbEstados_TbPaises_IdPais",
                table: "TbEstados",
                column: "IdPais",
                principalTable: "TbPaises",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbCidades_TbEstados_IdEstado",
                table: "TbCidades");

            migrationBuilder.DropForeignKey(
                name: "FK_TbEstados_TbPaises_IdPais",
                table: "TbEstados");

            migrationBuilder.DropTable(
                name: "TbPaises");

            migrationBuilder.DropIndex(
                name: "IX_TbEstados_IdPais",
                table: "TbEstados");

            migrationBuilder.DropIndex(
                name: "IX_TbCidades_IdEstado",
                table: "TbCidades");

            migrationBuilder.DropColumn(
                name: "CodigoIBGE",
                table: "TbEstados");

            migrationBuilder.DropColumn(
                name: "DDD",
                table: "TbEstados");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "TbEstados");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "TbEstados");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "TbCidades");
        }
    }
}
