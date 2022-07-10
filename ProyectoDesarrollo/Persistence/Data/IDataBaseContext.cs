using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.Persistence.Data;

public interface IDataBaseContext
{
    DbContext DbContext
    {
        get;
    }

    DbSet<Administrador> Administradores { get; set; }
    DbSet<Cotizacion> Cotizaciones { get; set; }
    DbSet<Factura> Facturas { get; set; }
    DbSet<Incidente> Incidentes { get; set; }
    DbSet<Marca> Marcas { get; set; }
    DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; }
    DbSet<Perito> Peritos { get; set; }
    DbSet<Pieza> Piezas { get; set; }
    DbSet<PiezaCotizacion> PiezasCotizaciones { get; set; }
    DbSet<PiezaMarca> PiezasMarcas { get; set; }
    DbSet<Poliza> Polizas { get; set; }
    DbSet<Propietario> Propietarios { get; set; }
    DbSet<Proveedor> Proveedores { get; set; }
    DbSet<ProveedorMarca> ProveedoresMarcas { get; set; }
    DbSet<Taller> Talleres { get; set; }
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Vehiculo> Vehiculos { get; set; }
    DbSet<VehiculoIncidenteTaller> VehiculosIncidentesTalleres { get; set; }

}