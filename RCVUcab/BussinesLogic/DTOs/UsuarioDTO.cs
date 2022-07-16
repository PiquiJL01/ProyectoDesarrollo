using System;
using System.Collections.Generic;


namespace RCVUcab.BussinesLogic.DTOs
{
    public class UsuarioDTO
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Rol { get; set; }
        public List<PolizaDTO> Poliza { get; set; }
        public List<IncidenteDTO> Incidente { get; set; }
        public List<OrdenDeCompraDTO> OrdenDeCompra { get; set; }
    }
}

