using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Taller : Usuario
    {
        public Taller()
        {
            CotizacionT = new HashSet<Cotizacion>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTaller>();
            
        }


        public string Id_Taller { get; set; } = null!;
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public Proveedor Proveedor { get; set; }

        public virtual ICollection<Cotizacion> CotizacionT { get; set; }

        public virtual ICollection<VehiculoIncidenteTaller> VehiculoIncidenteTaller { get; set; }

    }
}
