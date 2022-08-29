using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespensaBarrial.BD.Migrations
{
    public partial class GraciasTotales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdadEmpleado = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: true),
                    DNI = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    AdministadorId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stockDeposito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadMinima = table.Column<int>(type: "int", nullable: false),
                    CategoriaProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoDepositoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockDeposito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stockDeposito_empleado_EmpleadoDepositoId",
                        column: x => x.EmpleadoDepositoId,
                        principalTable: "empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAdministador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    proveedorId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_administrador_Proveedores_proveedorId",
                        column: x => x.proveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveProducto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimientoProducto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioProducto = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    DepositoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_stockDeposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "stockDeposito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeCategoria = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    ProveedoresId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categorias_Proveedores_ProveedoresId",
                        column: x => x.ProveedoresId,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrador_proveedorId",
                table: "administrador",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProductosId",
                table: "Categorias",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProveedoresId",
                table: "Categorias",
                column: "ProveedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepositoId",
                table: "Productos",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_stockDeposito_EmpleadoDepositoId",
                table: "stockDeposito",
                column: "EmpleadoDepositoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrador");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "stockDeposito");

            migrationBuilder.DropTable(
                name: "empleado");
        }
    }
}
