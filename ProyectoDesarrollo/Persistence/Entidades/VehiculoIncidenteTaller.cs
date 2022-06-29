using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class VehiculoIncidenteTaller
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; }

        public string Id_Vehiculo { get; set; }
        public string Id_Incidente { get; set; }
        public string Id_Taller { get; set; }
        public string Id_Pieza { get; set; }


        public Vehiculo Vehiculo { get; set; }
        public Incidente Incidente { get; set; }
        public Taller Taller { get; set; }
        public Pieza Pieza { get; set; }

    }
}