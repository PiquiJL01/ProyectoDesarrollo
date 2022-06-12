using System.Security.Principal;
using ProyectoDesarrollo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ProyectoDesarrollo.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        //public DbSet<Class> Classes { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<PrecioPieza> PrecioPiezas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculoIncidenteTaller> VehiculosIncidentesTalleres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>().ToTable("TableName");
            modelBuilder.Entity<Cotizacion>().ToTable("Cotizaciones");
            modelBuilder.Entity<Dueño>().ToTable("Dueños");
            modelBuilder.Entity<Factura>().ToTable("Facturas");
            modelBuilder.Entity<Incidente>().ToTable("Incidentes");
            modelBuilder.Entity<Marca>().ToTable("Marcas");
            modelBuilder.Entity<OrdenDeCompra>().ToTable("Ordenes de Compra");
            modelBuilder.Entity<Pieza>().ToTable("Piezas");
            modelBuilder.Entity<Poliza>().ToTable("Polizas");
            modelBuilder.Entity<PrecioPieza>().ToTable("Precio de la Pieza");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Taller>().ToTable("Talleres");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculos");
            modelBuilder.Entity<VehiculoIncidenteTaller>().ToTable("Talleres asignados a Vehiculo del Incidente");
        }
    }
}