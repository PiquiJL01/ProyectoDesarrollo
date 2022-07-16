using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class ProveedorEntity
    {
        public ProveedorEntity()
        {
            Cotizacion = new HashSet<CotizacionEntity>();
            ProveedorMarca = new HashSet<ProveedorMarcaEntity>();
        }

        
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string Id_Taller { get; set; }

        public string TallerID { get; set; }
        public TallerEntity Taller { get; set; }


        public ICollection<ProveedorMarcaEntity> ProveedorMarca { get; set; }


        public ICollection<CotizacionEntity> Cotizacion { get; set; }

        //public Taller Taller { get; set; }
    }
}
