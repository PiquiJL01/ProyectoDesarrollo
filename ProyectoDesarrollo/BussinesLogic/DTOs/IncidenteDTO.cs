using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class IncidenteDTO
    {
        public string ID { get; set; } = null!;
        public string Ubicacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Id_Perito { get; set; }
        public string Id_Administrador { get; set; }

        public List<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }

        public List<CotizacionDTO> Cotizacion { get; set; }

        public PeritoDTO Perito { get; set; }
        public AdministradorDTO Administrador { get; set; }
    }
}

