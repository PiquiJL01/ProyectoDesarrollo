using System;
namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class OrdenDeCompraDTO
    {
        public string ID { get; set; }
        public string Id_Administrador { get; set; }
        public CotizacionDTO Id_Cotizacion { get; set; }
        public AdministradorDTO Administrador { get; set; }
    }
}

