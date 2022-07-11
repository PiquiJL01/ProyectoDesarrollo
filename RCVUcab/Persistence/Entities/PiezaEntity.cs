using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Persistence.Entities
{
    public class PiezaEntity
    {

        public PiezaEntity()
        {
            PiezaCotizacion = new HashSet<PiezaCotizacionEntity>();
            PiezaMarca = new HashSet<PiezaMarcaEntity>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTallerEntity>();
        }

        public string ID { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        public ICollection<PiezaCotizacionEntity> PiezaCotizacion { get; set; } = null!;

        public ICollection<PiezaMarcaEntity> PiezaMarca { get; set; } = null!;

        public virtual ICollection<VehiculoIncidenteTallerEntity> VehiculoIncidenteTaller { get; set; }
    }
}
