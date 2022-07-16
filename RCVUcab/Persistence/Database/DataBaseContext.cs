using RCVUcab.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RCVUcab.Persistence.Database
{
    public partial class DataBaseContext : DbContext,IDataBaseContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        //public DbSet<Class> Classes { get; set; }
        public DbSet<CotizacionEntity> Cotizaciones { get; set; }
        public DbSet<FacturaEntity> Facturas { get; set; }
        public DbSet<IncidenteEntity> Incidentes { get; set; }
        public DbSet<MarcaEntity> Marcas { get; set; }
        public DbSet<OrdenDeCompraEntity> OrdenesDeCompra { get; set; }
        public DbSet<PiezaEntity> Piezas { get; set; }
        public DbSet<PiezaCotizacionEntity> PiezasCotizaciones { get; set; }
        public DbSet<PiezaMarcaEntity> PiezasMarcas { get; set; }
        public DbSet<PolizaEntity> Polizas { get; set; }
        public DbSet<PropietarioEntity> Propietarios { get; set; }
        public DbSet<ProveedorEntity> Proveedores { get; set; }
        public DbSet<ProveedorMarcaEntity> ProveedoresMarcas { get; set; }
        public DbSet<TallerEntity> Talleres { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<VehiculoEntity> Vehiculos { get; set; }
        public DbSet<VehiculoIncidenteTallerEntity> VehiculosIncidentesTalleres { get; set; }
        public IEnumerable<object> Administrador { get; internal set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>().ToTable("TableName");
            /*modelBuilder.Entity<Cotizacion>().ToTable("Cotizaciones");
            modelBuilder.Entity<Propietario>().ToTable("Duenos");
            modelBuilder.Entity<Factura>().ToTable("Facturas");
            modelBuilder.Entity<Incidente>().ToTable("Incidentes");
            modelBuilder.Entity<Marca>().ToTable("Marcas");
            modelBuilder.Entity<OrdenDeCompra>().ToTable("Ordenes de Compra");
            modelBuilder.Entity<Pieza>().ToTable("Piezas");
            modelBuilder.Entity<Poliza>().ToTable("Polizas");
            modelBuilder.Entity<PiezaCotizacion>().ToTable("Precio de la Pieza");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Taller>().ToTable("Talleres");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculos");
            modelBuilder.Entity<VehiculoIncidenteTaller>().ToTable("Talleres asignados a Vehiculo del Incidente");*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //POLIZA
            modelBuilder.Entity<PolizaEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Admin, "IX_Poliza_IdAdmin");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Poliza)
                    .HasForeignKey(d => d.Id_Admin);
            });


            //PROPIETARIO
            modelBuilder.Entity<PropietarioEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Poliza, "IX_Propietario_IdPoliza");


                entity.HasOne(d => d.Poliza)
                    .WithMany(p => p.Propietario)
                    .HasForeignKey(d => d.Id_Poliza);


            });

            //VEHICULO
            modelBuilder.Entity<VehiculoEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Propietario, "IX_Vehiculo_IdPropietario");

                entity.HasIndex(e => e.Id_Marca, "IX_Vehiculo_IdMarca");

                entity.HasOne(d => d.Propietario)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.Id_Propietario);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.Id_Marca);
            });

            //PIEZA-MARCA
            modelBuilder.Entity<PiezaMarcaEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Pieza, "IX_PiezaMarca_IdPieza");

                entity.HasIndex(e => e.Id_Marca, "IX_PiezaMarca_IdMarca");

                entity.HasOne(d => d.Pieza)
                    .WithMany(p => p.PiezaMarca)
                    .HasForeignKey(d => d.Id_Pieza);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.PiezaMarca)
                    .HasForeignKey(d => d.Id_Marca);
            });

            //PIEZA-COTIZACION
            modelBuilder.Entity<PiezaCotizacionEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Pieza, "IX_PiezaCotizacion_IdPieza");

                entity.HasIndex(e => e.Id_Cotizacion, "IX_PiezaCotizacion_IdCotizacion");

                entity.HasOne(d => d.Pieza)
                    .WithMany(p => p.PiezaCotizacion)
                    .HasForeignKey(d => d.Id_Pieza);

                entity.HasOne(d => d.Cotizacion)
                    .WithMany(p => p.PiezaCotizacion)
                    .HasForeignKey(d => d.Id_Cotizacion);
            });
            

            //COTIZACION
            modelBuilder.Entity<CotizacionEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Proveedor, "IX_Cotizacion_IdProveedor");

                entity.HasIndex(e => e.Id_Incidente, "IX_Cotizacion_IdIncidente");

                entity.HasIndex(e => e.Id_Taller, "IX_Cotizacion_IdTaller");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Id_Proveedor);

                entity.HasOne(d => d.Incidente)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Id_Incidente);

                entity.HasOne(d => d.Taller)
                    .WithMany(p => p.CotizacionT)
                    .HasForeignKey(d => d.Id_Taller);
            });

            //ORDEN-DE-COMPRA
            modelBuilder.Entity<OrdenDeCompraEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Administrador, "IX_OrdernDeCompra_IdAdministrador");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.Id_Administrador);
            });

            //PROVEEDOR-MARCA
            modelBuilder.Entity<ProveedorMarcaEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Proveedor, "IX_ProveedorMarca_IdProveedor");

                entity.HasIndex(e => e.Id_Marca, "IX_ProveedorMarca_IdMarca");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.ProveedorMarca)
                    .HasForeignKey(d => d.Id_Proveedor);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.ProveedorMarca)
                    .HasForeignKey(d => d.Id_Marca);
            });

            //VEHICULO-INCIDENTE-TALLER-PIEZA
            modelBuilder.Entity<VehiculoIncidenteTallerEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Vehiculo, "IX_VehiculoIncidenteTaller_IdVehiculo");

                entity.HasIndex(e => e.Id_Incidente, "IX_VehiculoIncidenteTaller_IdIncidente");

                entity.HasIndex(e => e.Id_Taller, "IX_VehiculoIncidenteTaller_IdTaller");

                entity.HasIndex(e => e.Id_Pieza, "IX_VehiculoIncidenteTaller_IdPieza");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Vehiculo);

                entity.HasOne(d => d.Incidente)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Incidente);

                entity.HasOne(d => d.Taller)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Taller);

                entity.HasOne(d => d.Pieza)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Pieza);
            });


            //INCIDENTE
            modelBuilder.Entity<IncidenteEntity>(entity =>
            {
                entity.HasIndex(e => e.Id_Perito, "IX_Incidente_IdProveedor");

                entity.HasIndex(e => e.Id_Administrador, "IX_ProveedorMarca_IdMarca");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.Id_Administrador);
            });


            modelBuilder.Entity<TallerEntity>()
            .HasOne(b => b.Proveedor)
            .WithOne(i => i.Taller)
            .HasForeignKey<ProveedorEntity>(b => b.TallerID);

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}