using System;
using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTO.DTOs
{
    public class ProveedorDTO
    {
        public string Id_Proveedor { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string TallerID { get; set; }
        public TallerDTO Taller { get; set; }


        public List<ProveedorMarcaDTO> ProveedorMarca { get; set; }


        public List<CotizacionDTO> Cotizacion { get; set; }
    }
}

