using System;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Persistence.Entities
{
    public class VehiculoIncidenteTallerEntity
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


        public VehiculoEntity Vehiculo { get; set; }
        public IncidenteEntity Incidente { get; set; }
        public TallerEntity Taller { get; set; }
        public PiezaEntity Pieza { get; set; }

    }
}