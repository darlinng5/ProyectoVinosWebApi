using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class correciondeerrorentablaproducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Semilla_idProceso",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "idProceso",
                table: "Productos",
                newName: "idSemilla");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_idProceso",
                table: "Productos",
                newName: "IX_Productos_idSemilla");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Semilla_idSemilla",
                table: "Productos",
                column: "idSemilla",
                principalTable: "Semilla",
                principalColumn: "idSemilla",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Semilla_idSemilla",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "idSemilla",
                table: "Productos",
                newName: "idProceso");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_idSemilla",
                table: "Productos",
                newName: "IX_Productos_idProceso");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Semilla_idProceso",
                table: "Productos",
                column: "idProceso",
                principalTable: "Semilla",
                principalColumn: "idSemilla",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
