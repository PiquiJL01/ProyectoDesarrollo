using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Incidente
    {
        public Incidente()
        {
            Cotizacion = new HashSet<Cotizacion>();
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTaller>();
        }

        public string ID { get; set; } = null!;
        public string Ubicacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Id_Perito { get; set; }
        public string Id_Administrador { get; set; }

        public ICollection<VehiculoIncidenteTaller> VehiculoIncidenteTaller { get; set; }

        public ICollection<Cotizacion> Cotizacion { get; set; }

        public Perito Perito { get; set; }
        public Administrador Administrador { get; set; }
        

    }
}
