using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendRentCar2._0.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Tipo_Persona = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    No_TarjetaCR = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Limite_Credito = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id_Documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id_Documento);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Tanda_Labor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Porciento_Comision = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id_Empleado);
                });

            migrationBuilder.CreateTable(
                name: "Marcass",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcass", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "TiposdeCombustibles",
                columns: table => new
                {
                    Id_TiposCombustible = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposdeCombustibles", x => x.Id_TiposCombustible);
                });

            migrationBuilder.CreateTable(
                name: "TiposdeVehiculos",
                columns: table => new
                {
                    Id_TiposVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposdeVehiculos", x => x.Id_TiposVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id_Modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Marca = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id_Modelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcass",
                        column: x => x.Id_Marca,
                        principalTable: "Marcass",
                        principalColumn: "Id_Marca");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id_Vehiculos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    No_Chasis = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    No_Motor = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    No_Placa = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Tipo_Vehiculo = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<int>(type: "int", nullable: false),
                    Tipo_Combustible = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos_1", x => x.Id_Vehiculos);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcass",
                        column: x => x.Marca,
                        principalTable: "Marcass",
                        principalColumn: "Id_Marca");
                    table.ForeignKey(
                        name: "FK_Vehiculos_Modelos",
                        column: x => x.Modelo,
                        principalTable: "Modelos",
                        principalColumn: "Id_Modelo");
                    table.ForeignKey(
                        name: "FK_Vehiculos_TiposdeCombustibles",
                        column: x => x.Tipo_Combustible,
                        principalTable: "TiposdeCombustibles",
                        principalColumn: "Id_TiposCombustible");
                    table.ForeignKey(
                        name: "FK_Vehiculos_TiposdeVehiculos",
                        column: x => x.Tipo_Vehiculo,
                        principalTable: "TiposdeVehiculos",
                        principalColumn: "Id_TiposVehiculo");
                });

            migrationBuilder.CreateTable(
                name: "Inspeccion",
                columns: table => new
                {
                    Id_Transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehiculo = table.Column<int>(type: "int", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Tiene_Ralladuras = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cantidad_Combustible = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Goma_Respuesta = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Gato = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Roturas = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Estado_Gomas = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Empleado_Inspeccion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspeccion", x => x.Id_Transaccion);
                    table.ForeignKey(
                        name: "FK_Inspeccion_Clientes",
                        column: x => x.Id_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente");
                    table.ForeignKey(
                        name: "FK_Inspeccion_Empleados",
                        column: x => x.Empleado_Inspeccion,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado");
                    table.ForeignKey(
                        name: "FK_Inspeccion_Vehiculos",
                        column: x => x.Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id_Vehiculos");
                });

            migrationBuilder.CreateTable(
                name: "Renta",
                columns: table => new
                {
                    Id_Renta = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doc_Garantia = table.Column<int>(type: "int", nullable: true),
                    Empleado = table.Column<int>(type: "int", nullable: false),
                    Vehiculo = table.Column<int>(type: "int", nullable: false),
                    Cliente = table.Column<int>(type: "int", nullable: false),
                    FechaRenta = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime", nullable: false),
                    MontoxDia = table.Column<decimal>(type: "money", nullable: false),
                    CantidadDias = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Abono = table.Column<decimal>(type: "money", nullable: true),
                    Comentario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentayDevolucion", x => x.Id_Renta);
                    table.ForeignKey(
                        name: "FK_Renta_Clientes",
                        column: x => x.Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente");
                    table.ForeignKey(
                        name: "FK_Renta_Documento",
                        column: x => x.Doc_Garantia,
                        principalTable: "Documento",
                        principalColumn: "Id_Documento");
                    table.ForeignKey(
                        name: "FK_Renta_Empleados",
                        column: x => x.Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado");
                    table.ForeignKey(
                        name: "FK_Renta_Vehiculos",
                        column: x => x.Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id_Vehiculos");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccion_Empleado_Inspeccion",
                table: "Inspeccion",
                column: "Empleado_Inspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccion_Id_Cliente",
                table: "Inspeccion",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccion_Vehiculo",
                table: "Inspeccion",
                column: "Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Id_Marca",
                table: "Modelos",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Cliente",
                table: "Renta",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Doc_Garantia",
                table: "Renta",
                column: "Doc_Garantia");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Empleado",
                table: "Renta",
                column: "Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_Vehiculo",
                table: "Renta",
                column: "Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Marca",
                table: "Vehiculos",
                column: "Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Modelo",
                table: "Vehiculos",
                column: "Modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Tipo_Combustible",
                table: "Vehiculos",
                column: "Tipo_Combustible");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Tipo_Vehiculo",
                table: "Vehiculos",
                column: "Tipo_Vehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspeccion");

            migrationBuilder.DropTable(
                name: "Renta");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TiposdeCombustibles");

            migrationBuilder.DropTable(
                name: "TiposdeVehiculos");

            migrationBuilder.DropTable(
                name: "Marcass");
        }
    }
}
