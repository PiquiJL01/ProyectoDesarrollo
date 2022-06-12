using System.Collections.Generic;

namespace ProyectoDesarrollo.Models
{
    public class Proveedor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Marca> Marcas { get; set; }
    }
}
