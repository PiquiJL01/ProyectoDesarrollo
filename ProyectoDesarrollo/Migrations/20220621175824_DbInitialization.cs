using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDesarrollo.Migrations
{
    public partial class DbInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duenos",
                columns: table => new
                {
                    CedulaRif = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duenos", x => x.CedulaRif);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.ID);
                });

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
                name: "Proveedores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPoliza = table.Column<int>(type: "int", nullable: false),
                    DuenoCedulaRif = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polizas_Duenos_DuenoCedulaRif",
                        column: x => x.DuenoCedulaRif,
                        principalTable: "Duenos",
                        principalColumn: "CedulaRif",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Piezas_Marcas_MarcaName",
                        column: x => x.MarcaName,
                        principalTable: "Marcas",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MarcaName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialCarroceria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    DuenoCedulaRif = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    NumeroDeEjes = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDePuestos = table.Column<int>(type: "int", nullable: false),
                    IncidenteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Placa);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Duenos_DuenoCedulaRif",
                        column: x => x.DuenoCedulaRif,
                        principalTable: "Duenos",
                        principalColumn: "CedulaRif",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Incidentes_IncidenteID",
                        column: x => x.IncidenteID,
                        principalTable: "Incidentes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_MarcaName",
                        column: x => x.MarcaName,
                        principalTable: "Marcas",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarcaProveedor",
                columns: table => new
                {
                    MarcasName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProovedoresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaProveedor", x => new { x.MarcasName, x.ProovedoresID });
                    table.ForeignKey(
                        name: "FK_MarcaProveedor_Marcas_MarcasName",
                        column: x => x.MarcasName,
                        principalTable: "Marcas",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaProveedor_Proveedores_ProovedoresID",
                        column: x => x.ProovedoresID,
                        principalTable: "Proveedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    ProveedorID = table.Column<int>(type: "int", nullable: true),
                    TallerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Proveedores_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "Proveedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talleres asignados a Vehiculo del Incidente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IncidenteID = table.Column<int>(type: "int", nullable: true),
                    TallerId = table.Column<int>(type: "int", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres asignados a Vehiculo del Incidente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Talleres asignados a Vehiculo del Incidente_Incidentes_IncidenteID",
                        column: x => x.IncidenteID,
                        principalTable: "Incidentes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talleres asignados a Vehiculo del Incidente_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talleres asignados a Vehiculo del Incidente_Vehiculos_VehiculoPlaca",
                        column: x => x.VehiculoPlaca,
                        principalTable: "Vehiculos",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoIncidenteTallerID = table.Column<int>(type: "int", nullable: true),
                    MontoTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Talleres asignados a Vehiculo del Incidente_VehiculoIncidenteTallerID",
                        column: x => x.VehiculoIncidenteTallerID,
                        principalTable: "Talleres asignados a Vehiculo del Incidente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes de Compra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorID = table.Column<int>(type: "int", nullable: true),
                    CotizacionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes de Compra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ordenes de Compra_Cotizaciones_CotizacionID",
                        column: x => x.CotizacionID,
                        principalTable: "Cotizaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes de Compra_Proveedores_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "Proveedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precio de la Pieza",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiezaID = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    CotizacionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio de la Pieza", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Precio de la Pieza_Cotizaciones_CotizacionID",
                        column: x => x.CotizacionID,
                        principalTable: "Cotizaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Precio de la Pieza_Piezas_PiezaID",
                        column: x => x.PiezaID,
                        principalTable: "Piezas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenDeCompraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturas_Ordenes de Compra_OrdenDeCompraID",
                        column: x => x.OrdenDeCompraID,
                        principalTable: "Ordenes de Compra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_VehiculoIncidenteTallerID",
                table: "Cotizaciones",
                column: "VehiculoIncidenteTallerID");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_OrdenDeCompraID",
                table: "Facturas",
                column: "OrdenDeCompraID");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaProveedor_ProovedoresID",
                table: "MarcaProveedor",
                column: "ProovedoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes de Compra_CotizacionID",
                table: "Ordenes de Compra",
                column: "CotizacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes de Compra_ProveedorID",
                table: "Ordenes de Compra",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_MarcaName",
                table: "Piezas",
                column: "MarcaName");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_DuenoCedulaRif",
                table: "Polizas",
                column: "DuenoCedulaRif");

            migrationBuilder.CreateIndex(
                name: "IX_Precio de la Pieza_CotizacionID",
                table: "Precio de la Pieza",
                column: "CotizacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Precio de la Pieza_PiezaID",
                table: "Precio de la Pieza",
                column: "PiezaID");

            migrationBuilder.CreateIndex(
                name: "IX_Talleres asignados a Vehiculo del Incidente_IncidenteID",
                table: "Talleres asignados a Vehiculo del Incidente",
                column: "IncidenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Talleres asignados a Vehiculo del Incidente_TallerId",
                table: "Talleres asignados a Vehiculo del Incidente",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_Talleres asignados a Vehiculo del Incidente_VehiculoPlaca",
                table: "Talleres asignados a Vehiculo del Incidente",
                column: "VehiculoPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProveedorID",
                table: "Usuarios",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TallerId",
                table: "Usuarios",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_DuenoCedulaRif",
                table: "Vehiculos",
                column: "DuenoCedulaRif");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IncidenteID",
                table: "Vehiculos",
                column: "IncidenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MarcaName",
                table: "Vehiculos",
                column: "MarcaName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "MarcaProveedor");

            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Precio de la Pieza");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ordenes de Compra");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Talleres asignados a Vehiculo del Incidente");

            migrationBuilder.DropTable(
                name: "Talleres");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Duenos");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
