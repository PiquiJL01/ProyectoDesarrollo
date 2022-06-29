using System;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;

namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class AdministradorDTO
    {
            public string Id_Admin { get; set; } = null!;

            public List<PolizaDTO> Poliza { get; set; }
            public List<IncidenteDTO> Incidente { get; set; }
            public List<OrdenDeCompraDTO> OrdenDeCompra { get; set; }
    }
}

