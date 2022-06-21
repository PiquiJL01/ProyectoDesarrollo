using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Vehiculo
    {
        [Key]
        public string Placa { get; set; }
        [Required]
        public Marca Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string SerialCarroceria { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public Dueno Dueno { get; set; }
        [Required]
        public int Peso { get; set; }
        [Required]
        public int NumeroDeEjes { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int NumeroDePuestos { get; set; }
    }
}
