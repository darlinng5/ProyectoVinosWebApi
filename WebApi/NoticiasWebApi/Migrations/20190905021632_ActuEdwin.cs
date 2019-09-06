using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class ActuEdwin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LlamadasAFinca_FincaProceso_idProceso",
                table: "LlamadasAFinca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LlamadasAFinca",
                table: "LlamadasAFinca");

            migrationBuilder.RenameTable(
                name: "LlamadasAFinca",
                newName: "LLamadasAFinca");

            migrationBuilder.RenameIndex(
                name: "IX_LlamadasAFinca_idProceso",
                table: "LLamadasAFinca",
                newName: "IX_LLamadasAFinca_idProceso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LLamadasAFinca",
                table: "LLamadasAFinca",
                column: "idLLamada");

            migrationBuilder.AddForeignKey(
                name: "FK_LLamadasAFinca_FincaProceso_idProceso",
                table: "LLamadasAFinca",
                column: "idProceso",
                principalTable: "FincaProceso",
                principalColumn: "idProceso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LLamadasAFinca_FincaProceso_idProceso",
                table: "LLamadasAFinca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LLamadasAFinca",
                table: "LLamadasAFinca");

            migrationBuilder.RenameTable(
                name: "LLamadasAFinca",
                newName: "LlamadasAFinca");

            migrationBuilder.RenameIndex(
                name: "IX_LLamadasAFinca_idProceso",
                table: "LlamadasAFinca",
                newName: "IX_LlamadasAFinca_idProceso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LlamadasAFinca",
                table: "LlamadasAFinca",
                column: "idLLamada");

            migrationBuilder.AddForeignKey(
                name: "FK_LlamadasAFinca_FincaProceso_idProceso",
                table: "LlamadasAFinca",
                column: "idProceso",
                principalTable: "FincaProceso",
                principalColumn: "idProceso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
