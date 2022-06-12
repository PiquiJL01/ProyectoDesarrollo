using System.Security.Principal;

namespace ProyectoDesarrollo.Models
{
    public class OrdenDeCompra
    {
        public int ID { get; set; }
        public Proveedor Proveedor { get; set; }
        public Cotizacion Cotizacion { get; set; }
    }
}
