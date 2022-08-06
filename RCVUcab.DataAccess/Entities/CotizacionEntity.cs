namespace RCVUcab.DataAccess.Entities
{
    public class CotizacionEntity
    {
        public CotizacionEntity()
        {
            PiezaCotizacion = new HashSet<PiezaCotizacionEntity>();
            
        }


        public string Id { get; set; } = null!;
        public double MontoTotal { get; set; }
        public string Observacion { get; set; }
        public string CotizacionEstatus { get; set; }
        public string Id_Proveedor { get; set; }
        public string Id_Incidente { get; set; }
        public string Id_Taller { get; set; }


        //public VehiculoIncidenteTaller VehiculoIncidenteTaller { get; set; }
        //public ICollection<PrecioPieza> PrecioPiezas { get; set; }


        public TallerEntity Taller { get; set; }
        public IncidenteEntity Incidente { get; set; }
        public ProveedorEntity Proveedor { get; set; }

        public virtual ICollection<PiezaCotizacionEntity> PiezaCotizacion { get; set; }
    }
}
