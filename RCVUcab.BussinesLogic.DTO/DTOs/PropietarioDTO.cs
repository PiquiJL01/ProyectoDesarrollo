using System;
using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTO.DTOs
{
    public class PropietarioDTO
    {
        public string CedulaRif { get; set; } = null!;

        public string PrimerNombre { get; set; } = null!;
        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; } = null!;
        public string Id_Poliza { get; set; } = null!;


        //public PolizaDTO Poliza { get; set; } = null!;
        //public List<VehiculoDTO> Vehiculo { get; set; }
    }
}

