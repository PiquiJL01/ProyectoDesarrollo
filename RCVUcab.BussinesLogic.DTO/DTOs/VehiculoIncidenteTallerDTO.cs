using System;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.BussinesLogic.DTO.DTOs
{
    public class VehiculoIncidenteTallerDTO
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


        public VehiculoDTO Vehiculo { get; set; }
        public IncidenteDTO Incidente { get; set; }
        public TallerDTO Taller { get; set; }
        public PiezaDTO Pieza { get; set; }
    }
}

