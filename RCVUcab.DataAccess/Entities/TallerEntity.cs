namespace RCVUcab.DataAccess.Entities
{
    public class TallerEntity
    {
        public TallerEntity()
        {
            CotizacionT = new HashSet<CotizacionEntity>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTallerEntity>();
            ProveedorMarca = new HashSet<ProveedorMarcaEntity>();

        }


        public string ID { get; set; } = null!;
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public ProveedorEntity Proveedor { get; set; }

        public virtual ICollection<CotizacionEntity> CotizacionT { get; set; }

        public virtual ICollection<VehiculoIncidenteTallerEntity> VehiculoIncidenteTaller { get; set; }

        public ICollection<ProveedorMarcaEntity> ProveedorMarca { get; set; }

    }
}
