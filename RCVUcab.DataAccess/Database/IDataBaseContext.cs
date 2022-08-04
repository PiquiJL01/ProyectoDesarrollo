using Microsoft.EntityFrameworkCore;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.Database
{

    public interface IDataBaseContext
    {
        DbContext DbContext { get; }

        DbSet<CotizacionEntity> Cotizaciones { get; set; }
        DbSet<FacturaEntity> Facturas { get; set; }
        DbSet<IncidenteEntity> Incidentes { get; set; }
        DbSet<MarcaEntity> Marcas { get; set; }
        DbSet<OrdenDeCompraEntity> OrdenesDeCompra { get; set; }
        DbSet<PiezaEntity> Piezas { get; set; }
        DbSet<PiezaCotizacionEntity> PiezasCotizaciones { get; set; }
        DbSet<PiezaMarcaEntity> PiezasMarcas { get; set; }
        DbSet<PolizaEntity> Polizas { get; set; }
        DbSet<PropietarioEntity> Propietarios { get; set; }
        DbSet<ProveedorEntity> Proveedores { get; set; }
        DbSet<ProveedorMarcaEntity> ProveedoresMarcas { get; set; }
        DbSet<TallerEntity> Talleres { get; set; }
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<VehiculoEntity> Vehiculos { get; set; }
        DbSet<VehiculoIncidenteTallerEntity> VehiculosIncidentesTalleres { get; set; }

    }
}