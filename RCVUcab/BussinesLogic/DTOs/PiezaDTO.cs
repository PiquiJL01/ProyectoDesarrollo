using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class PiezaDTO
    {
        public string ID { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; }


        public List<PiezaCotizacionDTO> PiezaCotizacion { get; set; } = null!;

        public List<PiezaMarcaDTO> PiezaMarca { get; set; } = null!;

        public virtual List<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }
    }
}

