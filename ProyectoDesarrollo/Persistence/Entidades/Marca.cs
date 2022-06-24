using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Marca
    {
        public Marca()
        {
            PiezaMarca = new HashSet<PiezaMarca>();
            ProveedorMarca = new HashSet<ProveedorMarca>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public string Name { get; set; }


        public ICollection<ProveedorMarca> ProveedorMarca { get; set; }

        public ICollection<PiezaMarca> PiezaMarca { get; set; }

        public ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
