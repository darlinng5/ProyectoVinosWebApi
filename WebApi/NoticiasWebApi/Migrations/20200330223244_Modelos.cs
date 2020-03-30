using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoVinowWebApi.Migrations
{
    public partial class Modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ajuste",
                columns: table => new
                {
                    idAjuste = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<float>(type: "float", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ajuste", x => x.idAjuste);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identidad = table.Column<string>(maxLength: 13, nullable: false),
                    Nombres = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    idDepartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 13, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.idDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecipiente",
                columns: table => new
                {
                    idTipoRecipiente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecipiente", x => x.idTipoRecipiente);
                });

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    idMunicipio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 13, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    idDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipio", x => x.idMunicipio);
                    table.ForeignKey(
                        name: "FK_municipio_departamento_idDepartamento",
                        column: x => x.idDepartamento,
                        principalTable: "departamento",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipiente",
                columns: table => new
                {
                    idRecipiente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Recipiente = table.Column<string>(maxLength: 70, nullable: false),
                    idTipoRecipiente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipiente", x => x.idRecipiente);
                    table.ForeignKey(
                        name: "FK_recipiente_TipoRecipiente_idTipoRecipiente",
                        column: x => x.idTipoRecipiente,
                        principalTable: "TipoRecipiente",
                        principalColumn: "idTipoRecipiente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "barrio",
                columns: table => new
                {
                    idBarrio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    idMunicipio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barrio", x => x.idBarrio);
                    table.ForeignKey(
                        name: "FK_barrio_municipio_idMunicipio",
                        column: x => x.idMunicipio,
                        principalTable: "municipio",
                        principalColumn: "idMunicipio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recoleccion",
                columns: table => new
                {
                    idRecoleccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Recoleccion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado_Clasificacion = table.Column<bool>(type: "bit", nullable: false),
                    idRecipiente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recoleccion", x => x.idRecoleccion);
                    table.ForeignKey(
                        name: "FK_recoleccion_recipiente_idRecipiente",
                        column: x => x.idRecipiente,
                        principalTable: "recipiente",
                        principalColumn: "idRecipiente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    idDireccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Refererncia = table.Column<string>(maxLength: 700, nullable: false),
                    idBarrio = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.idDireccion);
                    table.ForeignKey(
                        name: "FK_direccion_barrio_idBarrio",
                        column: x => x.idBarrio,
                        principalTable: "barrio",
                        principalColumn: "idBarrio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccion_cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "canjeo",
                columns: table => new
                {
                    idCanjeo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Canjeo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Puntos_Canjeados = table.Column<int>(type: "int", nullable: false),
                    Valor_En_Dinero = table.Column<double>(type: "float", nullable: false),
                    idDireccion = table.Column<int>(type: "int", nullable: false),
                    direccionidDireccion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canjeo", x => x.idCanjeo);
                    table.ForeignKey(
                        name: "FK_canjeo_direccion_direccionidDireccion",
                        column: x => x.direccionidDireccion,
                        principalTable: "direccion",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "puntos",
                columns: table => new
                {
                    idPuntos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    idDireccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntos", x => x.idPuntos);
                    table.ForeignKey(
                        name: "FK_puntos_direccion_idDireccion",
                        column: x => x.idDireccion,
                        principalTable: "direccion",
                        principalColumn: "idDireccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_barrio_idMunicipio",
                table: "barrio",
                column: "idMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_canjeo_direccionidDireccion",
                table: "canjeo",
                column: "direccionidDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_idBarrio",
                table: "direccion",
                column: "idBarrio");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_idCliente",
                table: "direccion",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_municipio_idDepartamento",
                table: "municipio",
                column: "idDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_puntos_idDireccion",
                table: "puntos",
                column: "idDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_recipiente_idTipoRecipiente",
                table: "recipiente",
                column: "idTipoRecipiente");

            migrationBuilder.CreateIndex(
                name: "IX_recoleccion_idRecipiente",
                table: "recoleccion",
                column: "idRecipiente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ajuste");

            migrationBuilder.DropTable(
                name: "canjeo");

            migrationBuilder.DropTable(
                name: "puntos");

            migrationBuilder.DropTable(
                name: "recoleccion");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "recipiente");

            migrationBuilder.DropTable(
                name: "barrio");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "TipoRecipiente");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "departamento");
        }
    }
}
