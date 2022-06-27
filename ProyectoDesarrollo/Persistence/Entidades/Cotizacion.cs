using System.Collections.Generic;
using System.Security.Principal;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Cotizacion
    {
        public Cotizacion()
        {
            PiezaCotizacion = new HashSet<PiezaCotizacion>();
            
        }


        public string Id { get; set; } = null!;
        public double MontoTotal { get; set; }
        public string Id_Proveedor { get; set; }
        public string Id_Incidente { get; set; }
        public string Id_Taller { get; set; }


        //public VehiculoIncidenteTaller VehiculoIncidenteTaller { get; set; }
        //public ICollection<PrecioPieza> PrecioPiezas { get; set; }


        public Taller Taller { get; set; }
        public Incidente Incidente { get; set; }
        public Proveedor Proveedor { get; set; }

        public virtual ICollection<PiezaCotizacion> PiezaCotizacion { get; set; }
    }
}
