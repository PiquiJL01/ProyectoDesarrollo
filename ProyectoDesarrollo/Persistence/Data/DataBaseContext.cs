using System.Security.Principal;
using ProyectoDesarrollo.Persistence.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ProyectoDesarrollo.Persistence.DataBase
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        //public DbSet<Class> Classes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; }
        public DbSet<Perito> Peritos { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<PiezaCotizacion> PiezasCotizaciones { get; set; }
        public DbSet<PiezaMarca> PiezasMarcas { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ProveedorMarca> ProveedoresMarcas { get; set; }
        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculoIncidenteTaller> VehiculosIncidentesTalleres { get; set; }

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
            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasIndex(e => e.Id_Admin, "IX_Poliza_IdAdmin");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Poliza)
                    .HasForeignKey(d => d.Id_Admin);
            });


            //PROPIETARIO
            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasIndex(e => e.Id_Poliza, "IX_Propietario_IdPoliza");


                entity.HasOne(d => d.Poliza)
                    .WithMany(p => p.Propietario)
                    .HasForeignKey(d => d.Id_Poliza);


            });

            //VEHICULO
            modelBuilder.Entity<Vehiculo>(entity =>
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
            modelBuilder.Entity<PiezaMarca>(entity =>
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
            modelBuilder.Entity<PiezaCotizacion>(entity =>
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
                modelBuilder.Entity<Cotizacion>(entity =>
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
            modelBuilder.Entity<OrdenDeCompra>(entity =>
            {
                entity.HasIndex(e => e.Id_Administrador, "IX_OrdernDeCompra_IdAdministrador");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.Id_Administrador);
            });

            //PROVEEDOR-MARCA
            modelBuilder.Entity<ProveedorMarca>(entity =>
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

            //VEHICULO-INCIDENTE-TALLER
            modelBuilder.Entity<VehiculoIncidenteTaller>(entity =>
            {
                entity.HasIndex(e => e.Id_Vehiculo, "IX_VehiculoIncidenteTaller_IdVehiculo");

                entity.HasIndex(e => e.Id_Incidente, "IX_VehiculoIncidenteTaller_IdIncidente");

                entity.HasIndex(e => e.Id_Taller, "IX_VehiculoIncidenteTaller_IdTaller");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Vehiculo);

                entity.HasOne(d => d.Incidente)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Incidente);

                entity.HasOne(d => d.Taller)
                    .WithMany(p => p.VehiculoIncidenteTaller)
                    .HasForeignKey(d => d.Id_Taller);
            });


            //INCIDENTE
            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.HasIndex(e => e.Id_Perito, "IX_Incidente_IdProveedor");

                entity.HasIndex(e => e.Id_Administrador, "IX_ProveedorMarca_IdMarca");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.Id_Administrador);

                entity.HasOne(d => d.Perito)
                    .WithMany(p => p.Incidente)
                    .HasForeignKey(d => d.Id_Perito);
            });


            /*modelBuilder.Entity<Incidente>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("{0:dd-MM-yyyy}");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.Property(e => e.FechaNacimiento).HasColumnType("{0:dd-MM-yyyy}");
            });*/

            modelBuilder.Entity<Taller>()
            .HasOne(b => b.Proveedor)
            .WithOne(i => i.Taller)
            .HasForeignKey<Proveedor>(b => b.TallerID);

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);




    }
    
}