using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class RelacionandoTablaFincaConProcesoFinca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idFinca",
                table: "FincaProceso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FincaProceso_idFinca",
                table: "FincaProceso",
                column: "idFinca");

            migrationBuilder.AddForeignKey(
                name: "FK_FincaProceso_Finca_idFinca",
                table: "FincaProceso",
                column: "idFinca",
                principalTable: "Finca",
                principalColumn: "idFinca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FincaProceso_Finca_idFinca",
                table: "FincaProceso");

            migrationBuilder.DropIndex(
                name: "IX_FincaProceso_idFinca",
                table: "FincaProceso");

            migrationBuilder.DropColumn(
                name: "idFinca",
                table: "FincaProceso");
        }
    }
}
