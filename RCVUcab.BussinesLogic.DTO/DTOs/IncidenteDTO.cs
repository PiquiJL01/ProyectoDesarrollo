using System.ComponentModel.DataAnnotations;

namespace RCVUcab.BussinesLogic.DTO.DTOs
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

        //public ICollection<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }
        //public ICollection<CotizacionDTO> Cotizacion { get; set; }
        //public UsuarioDTO Perito { get; set; }
        //public UsuarioDTO Administrador { get; set; }
    }
}

