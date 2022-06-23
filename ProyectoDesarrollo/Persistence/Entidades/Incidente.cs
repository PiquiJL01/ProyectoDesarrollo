using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Incidente
    {
        public int ID { get; set; }
        public string Ubicacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public ICollection<Vehiculo> Implicados { get; set; }
        
    }
}
