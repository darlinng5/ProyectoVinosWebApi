using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class AddTableFincaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoPresentacion",
                columns: table => new
                {
                    idProductoPresentacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPresentacion", x => x.idProductoPresentacion);
                });

            migrationBuilder.CreateTable(
                name: "FincaCompra",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valorUnitario = table.Column<decimal>(type: "decimal", nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal", nullable: false),
                    esPagoAlContado = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(maxLength: 150, nullable: true),
                    idProceso = table.Column<int>(type: "int", nullable: false),
                    idProductoPresentacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FincaCompra", x => x.id);
                    table.ForeignKey(
                        name: "FK_FincaCompra_FincaProceso_idProceso",
                        column: x => x.idProceso,
                        principalTable: "FincaProceso",
                        principalColumn: "idProceso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FincaCompra_ProductoPresentacion_idProductoPresentacion",
                        column: x => x.idProductoPresentacion,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "idProductoPresentacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FincaCompra_idProceso",
                table: "FincaCompra",
                column: "idProceso");

            migrationBuilder.CreateIndex(
                name: "IX_FincaCompra_idProductoPresentacion",
                table: "FincaCompra",
                column: "idProductoPresentacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FincaCompra");

            migrationBuilder.DropTable(
                name: "ProductoPresentacion");
        }
    }
}
