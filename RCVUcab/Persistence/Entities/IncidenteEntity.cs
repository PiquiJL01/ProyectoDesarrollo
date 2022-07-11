using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Persistence.Entities
{
    public class IncidenteEntity
    {
        public IncidenteEntity()
        {
            Cotizacion = new HashSet<CotizacionEntity>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTallerEntity>();
        }

        public string ID { get; set; } = null!;
        public string Ubicacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Id_Perito { get; set; }
        public string Id_Administrador { get; set; }

        public ICollection<VehiculoIncidenteTallerEntity> VehiculoIncidenteTaller { get; set; }

        public ICollection<CotizacionEntity> Cotizacion { get; set; }

        public PeritoEntity Perito { get; set; }
        public AdministradorEntity Administrador { get; set; }
        

    }
}
