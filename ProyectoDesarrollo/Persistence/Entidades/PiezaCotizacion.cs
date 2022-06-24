using System.Security.Principal;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class PiezaCotizacion
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Cotizacion { get; set; }
        public float Precio { get; set; }

        public Pieza Pieza { get; set; }
        public Cotizacion Cotizacion { get; set; }
    }
}
