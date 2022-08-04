using System;
using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTO.DTOs
{
    public class MarcaDTO
    {
        public string Name { get; set; }

        public List<ProveedorMarcaDTO> ProveedorMarca { get; set; }

        public List<PiezaMarcaDTO> PiezaMarca { get; set; }

        public List<VehiculoDTO> Vehiculo { get; set; }
    }
}

