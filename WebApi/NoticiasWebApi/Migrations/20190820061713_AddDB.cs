using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class AddDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoSemilla",
                table: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Productos",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "Productos",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Productos",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idProceso",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idProducto",
                table: "FincaProceso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Semilla",
                columns: table => new
                {
                    idSemilla = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 40, nullable: true),
                    descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    estado = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semilla", x => x.idSemilla);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idProceso",
                table: "Productos",
                column: "idProceso");

            migrationBuilder.CreateIndex(
                name: "IX_FincaProceso_idProducto",
                table: "FincaProceso",
                column: "idProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_FincaProceso_Productos_idProducto",
                table: "FincaProceso",
                column: "idProducto",
                principalTable: "Productos",
                principalColumn: "idProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Semilla_idProceso",
                table: "Productos",
                column: "idProceso",
                principalTable: "Semilla",
                principalColumn: "idSemilla",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FincaProceso_Productos_idProducto",
                table: "FincaProceso");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Semilla_idProceso",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Semilla");

            migrationBuilder.DropIndex(
                name: "IX_Productos_idProceso",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_FincaProceso_idProducto",
                table: "FincaProceso");

            migrationBuilder.DropColumn(
                name: "idProceso",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "idProducto",
                table: "FincaProceso");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoSemilla",
                table: "Productos",
                nullable: true);
        }
    }
}
