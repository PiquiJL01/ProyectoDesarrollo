#nullable enable
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Models
{
    public class Pieza
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public Marca Marca { get; set; }

        public Pieza(int iD, string name, string? description, Marca marca)
        {
            ID = iD;
            Name = name;
            Description = description;
            Marca = marca;
        }
    }
}
