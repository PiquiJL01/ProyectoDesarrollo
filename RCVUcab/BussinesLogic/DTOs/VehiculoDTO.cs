using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class VehiculoDTO
    {
        public string Placa { get; set; }
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


        public MarcaDTO Marca { get; set; } = null!;

        public PropietarioDTO Propietario { get; set; } = null;


        public List<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }
    }
}

