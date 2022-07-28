using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCVUcab.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PiezasMarcas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Pieza = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Marca = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezasMarcas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PiezasMarcas_Marcas_Id_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_PiezasMarcas_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TallerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proveedores_Talleres_TallerID",
                        column: x => x.TallerID,
                        principalTable: "Talleres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Perito = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Administrador = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PeritoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_Id_Administrador",
                        column: x => x.Id_Administrador,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_PeritoId",
                        column: x => x.PeritoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoPoliza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Admin = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polizas_Usuarios_Id_Admin",
                        column: x => x.Id_Admin,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProveedoresMarcas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Proveedor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Marca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Taller = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedoresMarcas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProveedoresMarcas_Marcas_Id_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_ProveedoresMarcas_Proveedores_Id_Proveedor",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProveedoresMarcas_Talleres_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Talleres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CotizacionEstatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Proveedor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Incidente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Taller = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Incidentes_Id_Incidente",
                        column: x => x.Id_Incidente,
                        principalTable: "Incidentes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Proveedores_Id_Proveedor",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Talleres_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Talleres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    CedulaRif = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Poliza = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.CedulaRif);
                    table.ForeignKey(
                        name: "FK_Propietarios_Polizas_Id_Poliza",
                        column: x => x.Id_Poliza,
                        principalTable: "Polizas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDeCompra",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Administrador = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_CotizacionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDeCompra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdenesDeCompra_Cotizaciones_Id_CotizacionId",
                        column: x => x.Id_CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenesDeCompra_Usuarios_Id_Administrador",
                        column: x => x.Id_Administrador,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PiezasCotizaciones",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Pieza = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Cotizacion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoDeEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PiezaEstatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezasCotizaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PiezasCotizaciones_Cotizaciones_Id_Cotizacion",
                        column: x => x.Id_Cotizacion,
                        principalTable: "Cotizaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PiezasCotizaciones_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialCarroceria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    NumeroDeEjes = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDePuestos = table.Column<int>(type: "int", nullable: false),
                    Id_Propietario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Marca = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Placa);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_Id_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Vehiculos_Propietarios_Id_Propietario",
                        column: x => x.Id_Propietario,
                        principalTable: "Propietarios",
                        principalColumn: "CedulaRif");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_OrdenDeCompraID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturas_OrdenesDeCompra_ID_OrdenDeCompraID",
                        column: x => x.ID_OrdenDeCompraID,
                        principalTable: "OrdenesDeCompra",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "VehiculosIncidentesTalleres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Vehiculo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Incidente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Taller = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Pieza = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosIncidentesTalleres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehiculosIncidentesTalleres_Incidentes_Id_Incidente",
                        column: x => x.Id_Incidente,
                        principalTable: "Incidentes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VehiculosIncidentesTalleres_Piezas_Id_Pieza",
                        column: x => x.Id_Pieza,
                        principalTable: "Piezas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VehiculosIncidentesTalleres_Talleres_Id_Taller",
                        column: x => x.Id_Taller,
                        principalTable: "Talleres",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VehiculosIncidentesTalleres_Vehiculos_Id_Vehiculo",
                        column: x => x.Id_Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Placa");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_IdIncidente",
                table: "Cotizaciones",
                column: "Id_Incidente");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_IdProveedor",
                table: "Cotizaciones",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_IdTaller",
                table: "Cotizaciones",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ID_OrdenDeCompraID",
                table: "Facturas",
                column: "ID_OrdenDeCompraID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidente_IdProveedor",
                table: "Incidentes",
                column: "Id_Perito");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_PeritoId",
                table: "Incidentes",
                column: "PeritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMarca_IdMarca",
                table: "Incidentes",
                column: "Id_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDeCompra_Id_CotizacionId",
                table: "OrdenesDeCompra",
                column: "Id_CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdernDeCompra_IdAdministrador",
                table: "OrdenesDeCompra",
                column: "Id_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaCotizacion_IdCotizacion",
                table: "PiezasCotizaciones",
                column: "Id_Cotizacion");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaCotizacion_IdPieza",
                table: "PiezasCotizaciones",
                column: "Id_Pieza");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaMarca_IdMarca",
                table: "PiezasMarcas",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaMarca_IdPieza",
                table: "PiezasMarcas",
                column: "Id_Pieza");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_IdAdmin",
                table: "Polizas",
                column: "Id_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_Propietario_IdPoliza",
                table: "Propietarios",
                column: "Id_Poliza");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TallerID",
                table: "Proveedores",
                column: "TallerID",
                unique: true,
                filter: "[TallerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMarca_IdMarca1",
                table: "ProveedoresMarcas",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMarca_IdProveedor",
                table: "ProveedoresMarcas",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMarca_IdTaller",
                table: "ProveedoresMarcas",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdMarca",
                table: "Vehiculos",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdPropietario",
                table: "Vehiculos",
                column: "Id_Propietario");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoIncidenteTaller_IdIncidente",
                table: "VehiculosIncidentesTalleres",
                column: "Id_Incidente");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoIncidenteTaller_IdPieza",
                table: "VehiculosIncidentesTalleres",
                column: "Id_Pieza");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoIncidenteTaller_IdTaller",
                table: "VehiculosIncidentesTalleres",
                column: "Id_Taller");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoIncidenteTaller_IdVehiculo",
                table: "VehiculosIncidentesTalleres",
                column: "Id_Vehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "PiezasCotizaciones");

            migrationBuilder.DropTable(
                name: "PiezasMarcas");

            migrationBuilder.DropTable(
                name: "ProveedoresMarcas");

            migrationBuilder.DropTable(
                name: "VehiculosIncidentesTalleres");

            migrationBuilder.DropTable(
                name: "OrdenesDeCompra");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Talleres");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
