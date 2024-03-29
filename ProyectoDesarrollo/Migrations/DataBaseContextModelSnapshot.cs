﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoDesarrollo.Persistence.DataBase;

#nullable disable

namespace ProyectoDesarrollo.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Cotizacion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Incidente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Proveedor")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Taller")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id_Incidente" }, "IX_Cotizacion_IdIncidente");

                    b.HasIndex(new[] { "Id_Proveedor" }, "IX_Cotizacion_IdProveedor");

                    b.HasIndex(new[] { "Id_Taller" }, "IX_Cotizacion_IdTaller");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Factura", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_OrdenDeCompraID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("ID_OrdenDeCompraID");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Incidente", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id_Administrador")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Perito")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Perito" }, "IX_Incidente_IdProveedor");

                    b.HasIndex(new[] { "Id_Administrador" }, "IX_ProveedorMarca_IdMarca");

                    b.ToTable("Incidentes");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Marca", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.OrdenDeCompra", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Administrador")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_CotizacionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Id_CotizacionId");

                    b.HasIndex(new[] { "Id_Administrador" }, "IX_OrdernDeCompra_IdAdministrador");

                    b.ToTable("OrdenesDeCompra");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Pieza", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Piezas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.PiezaCotizacion", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Cotizacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Pieza")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Cotizacion" }, "IX_PiezaCotizacion_IdCotizacion");

                    b.HasIndex(new[] { "Id_Pieza" }, "IX_PiezaCotizacion_IdPieza");

                    b.ToTable("PiezasCotizaciones");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.PiezaMarca", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Marca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Pieza")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Marca" }, "IX_PiezaMarca_IdMarca");

                    b.HasIndex(new[] { "Id_Pieza" }, "IX_PiezaMarca_IdPieza");

                    b.ToTable("PiezasMarcas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Poliza", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Admin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TipoPoliza")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Admin" }, "IX_Poliza_IdAdmin");

                    b.ToTable("Polizas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Propietario", b =>
                {
                    b.Property<string>("CedulaRif")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id_Poliza")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CedulaRif");

                    b.HasIndex(new[] { "Id_Poliza" }, "IX_Propietario_IdPoliza");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.ProveedorMarca", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Marca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Proveedor")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Marca" }, "IX_ProveedorMarca_IdMarca")
                        .HasDatabaseName("IX_ProveedorMarca_IdMarca1");

                    b.HasIndex(new[] { "Id_Proveedor" }, "IX_ProveedorMarca_IdProveedor");

                    b.ToTable("ProveedoresMarcas");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Vehiculo", b =>
                {
                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_Marca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Propietario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDeEjes")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDePuestos")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("SerialCarroceria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Placa");

                    b.HasIndex(new[] { "Id_Marca" }, "IX_Vehiculo_IdMarca");

                    b.HasIndex(new[] { "Id_Propietario" }, "IX_Vehiculo_IdPropietario");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.VehiculoIncidenteTaller", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id_Incidente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Pieza")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Taller")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Vehiculo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Id_Incidente" }, "IX_VehiculoIncidenteTaller_IdIncidente");

                    b.HasIndex(new[] { "Id_Pieza" }, "IX_VehiculoIncidenteTaller_IdPieza");

                    b.HasIndex(new[] { "Id_Taller" }, "IX_VehiculoIncidenteTaller_IdTaller");

                    b.HasIndex(new[] { "Id_Vehiculo" }, "IX_VehiculoIncidenteTaller_IdVehiculo");

                    b.ToTable("VehiculosIncidentesTalleres");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Administrador", b =>
                {
                    b.HasBaseType("ProyectoDesarrollo.Persistence.Entidades.Usuario");

                    b.Property<string>("Id_Admin")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Perito", b =>
                {
                    b.HasBaseType("ProyectoDesarrollo.Persistence.Entidades.Usuario");

                    b.Property<string>("Id_Perito")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Perito");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Proveedor", b =>
                {
                    b.HasBaseType("ProyectoDesarrollo.Persistence.Entidades.Usuario");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Proveedor_Address");

                    b.Property<string>("Id_Proveedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Proveedor_Name");

                    b.Property<string>("TallerID")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("TallerID")
                        .IsUnique()
                        .HasFilter("[TallerID] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Proveedor");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Taller", b =>
                {
                    b.HasBaseType("ProyectoDesarrollo.Persistence.Entidades.Usuario");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_Taller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Taller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Cotizacion", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Incidente", "Incidente")
                        .WithMany("Cotizacion")
                        .HasForeignKey("Id_Incidente");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Proveedor", "Proveedor")
                        .WithMany("Cotizacion")
                        .HasForeignKey("Id_Proveedor");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Taller", "Taller")
                        .WithMany("CotizacionT")
                        .HasForeignKey("Id_Taller");

                    b.Navigation("Incidente");

                    b.Navigation("Proveedor");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Factura", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.OrdenDeCompra", "ID_OrdenDeCompra")
                        .WithMany()
                        .HasForeignKey("ID_OrdenDeCompraID");

                    b.Navigation("ID_OrdenDeCompra");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Incidente", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Administrador", "Administrador")
                        .WithMany("Incidente")
                        .HasForeignKey("Id_Administrador");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Perito", "Perito")
                        .WithMany("Incidente")
                        .HasForeignKey("Id_Perito");

                    b.Navigation("Administrador");

                    b.Navigation("Perito");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.OrdenDeCompra", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Administrador", "Administrador")
                        .WithMany("OrdenDeCompra")
                        .HasForeignKey("Id_Administrador");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Cotizacion", "Id_Cotizacion")
                        .WithMany()
                        .HasForeignKey("Id_CotizacionId");

                    b.Navigation("Administrador");

                    b.Navigation("Id_Cotizacion");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.PiezaCotizacion", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Cotizacion", "Cotizacion")
                        .WithMany("PiezaCotizacion")
                        .HasForeignKey("Id_Cotizacion");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Pieza", "Pieza")
                        .WithMany("PiezaCotizacion")
                        .HasForeignKey("Id_Pieza");

                    b.Navigation("Cotizacion");

                    b.Navigation("Pieza");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.PiezaMarca", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Marca", "Marca")
                        .WithMany("PiezaMarca")
                        .HasForeignKey("Id_Marca");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Pieza", "Pieza")
                        .WithMany("PiezaMarca")
                        .HasForeignKey("Id_Pieza");

                    b.Navigation("Marca");

                    b.Navigation("Pieza");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Poliza", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Administrador", "Administrador")
                        .WithMany("Poliza")
                        .HasForeignKey("Id_Admin");

                    b.Navigation("Administrador");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Propietario", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Poliza", "Poliza")
                        .WithMany("Propietario")
                        .HasForeignKey("Id_Poliza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliza");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.ProveedorMarca", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Marca", "Marca")
                        .WithMany("ProveedorMarca")
                        .HasForeignKey("Id_Marca");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Proveedor", "Proveedor")
                        .WithMany("ProveedorMarca")
                        .HasForeignKey("Id_Proveedor");

                    b.Navigation("Marca");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Vehiculo", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Marca", "Marca")
                        .WithMany("Vehiculo")
                        .HasForeignKey("Id_Marca");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Propietario", "Propietario")
                        .WithMany("Vehiculo")
                        .HasForeignKey("Id_Propietario");

                    b.Navigation("Marca");

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.VehiculoIncidenteTaller", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Incidente", "Incidente")
                        .WithMany("VehiculoIncidenteTaller")
                        .HasForeignKey("Id_Incidente");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Pieza", "Pieza")
                        .WithMany("VehiculoIncidenteTaller")
                        .HasForeignKey("Id_Pieza");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Taller", "Taller")
                        .WithMany("VehiculoIncidenteTaller")
                        .HasForeignKey("Id_Taller");

                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("VehiculoIncidenteTaller")
                        .HasForeignKey("Id_Vehiculo");

                    b.Navigation("Incidente");

                    b.Navigation("Pieza");

                    b.Navigation("Taller");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Proveedor", b =>
                {
                    b.HasOne("ProyectoDesarrollo.Persistence.Entidades.Taller", "Taller")
                        .WithOne("Proveedor")
                        .HasForeignKey("ProyectoDesarrollo.Persistence.Entidades.Proveedor", "TallerID");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Cotizacion", b =>
                {
                    b.Navigation("PiezaCotizacion");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Incidente", b =>
                {
                    b.Navigation("Cotizacion");

                    b.Navigation("VehiculoIncidenteTaller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Marca", b =>
                {
                    b.Navigation("PiezaMarca");

                    b.Navigation("ProveedorMarca");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Pieza", b =>
                {
                    b.Navigation("PiezaCotizacion");

                    b.Navigation("PiezaMarca");

                    b.Navigation("VehiculoIncidenteTaller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Poliza", b =>
                {
                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Propietario", b =>
                {
                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Vehiculo", b =>
                {
                    b.Navigation("VehiculoIncidenteTaller");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Administrador", b =>
                {
                    b.Navigation("Incidente");

                    b.Navigation("OrdenDeCompra");

                    b.Navigation("Poliza");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Perito", b =>
                {
                    b.Navigation("Incidente");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Proveedor", b =>
                {
                    b.Navigation("Cotizacion");

                    b.Navigation("ProveedorMarca");
                });

            modelBuilder.Entity("ProyectoDesarrollo.Persistence.Entidades.Taller", b =>
                {
                    b.Navigation("CotizacionT");

                    b.Navigation("Proveedor");

                    b.Navigation("VehiculoIncidenteTaller");
                });
#pragma warning restore 612, 618
        }
    }
}
