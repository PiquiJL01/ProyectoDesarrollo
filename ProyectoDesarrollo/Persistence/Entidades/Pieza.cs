#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Pieza
    {

        public Pieza()
        {
            PiezaCotizacion = new HashSet<PiezaCotizacion>();
            PiezaMarca = new HashSet<PiezaMarca>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTaller>();
        }

        public string ID { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        public ICollection<PiezaCotizacion> PiezaCotizacion { get; set; } = null!;

        public ICollection<PiezaMarca> PiezaMarca { get; set; } = null!;

        public virtual ICollection<VehiculoIncidenteTaller> VehiculoIncidenteTaller { get; set; }


        /*[Required]
        public Marca Marca { get; set; } = null!;*/


        /*public Pieza(int iD, string name, string? description, Marca marca)
        {
            ID = iD;
            Name = name;
            Description = description;
            Marca = marca;
        }*/
    }
}
