using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Proveedor : Usuario
    {
        public Proveedor()
        {
            Cotizacion = new HashSet<Cotizacion>();
            ProveedorMarca = new HashSet<ProveedorMarca>();
        }

        
        public string Id_Proveedor { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string Id_Taller { get; set; }

        public string TallerID { get; set; }
        public Taller Taller { get; set; }


        public ICollection<ProveedorMarca> ProveedorMarca { get; set; }


        public ICollection<Cotizacion> Cotizacion { get; set; }

        //public Taller Taller { get; set; }
    }
}
