using System.Collections.Generic;
using System.Security.Principal;

namespace ProyectoDesarrollo.Models
{
    public class Cotizacion
    {
        public int ID { get; set; }
        public VehiculoIncidenteTaller VehiculoIncidenteTaller { get; set; }
        public ICollection<PrecioPieza> PrecioPiezas { get; set; }
        public double MontoTotal { get; set; }
    }
}
