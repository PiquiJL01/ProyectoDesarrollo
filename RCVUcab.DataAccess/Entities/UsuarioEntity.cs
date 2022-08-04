using System;
using System.Collections.Generic;

namespace RCVUcab.DataAccess.Entities
{
    public class UsuarioEntity
	{
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Rol { get; set; }
        public ICollection<PolizaEntity> Poliza { get; set; }
        public ICollection<IncidenteEntity> Incidente { get; set; }
        public ICollection<OrdenDeCompraEntity> OrdenDeCompra { get; set; }
    }
}
