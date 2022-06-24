using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Vehiculo
    {
        public Vehiculo()
        {
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTaller>();
        }


        [Key]
        public string Placa { get; set; }
        /*[Required]
        public Marca Marca { get; set; }*/
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
        /*[Required]
        public Propietario Propietario { get; set; }*/
        [Required]
        public int Peso { get; set; }
        [Required]
        public int NumeroDeEjes { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int NumeroDePuestos { get; set; }
        public string Id_Propietario { get; set; }
        public string Id_Marca { get; set; }


        public Marca Marca { get; set; } = null!;

        public Propietario Propietario { get; set; } = null;


        public ICollection<VehiculoIncidenteTaller> VehiculoIncidenteTaller { get; set; }
    }
}
