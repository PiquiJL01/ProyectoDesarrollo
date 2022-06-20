using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Models
{
    public class VehiculoIncidenteTaller
    {
        public int ID { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Incidente Incidente { get; set; }
        public Taller Taller { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; }
    }
}
