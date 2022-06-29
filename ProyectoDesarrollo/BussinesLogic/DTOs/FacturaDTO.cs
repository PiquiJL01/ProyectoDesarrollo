using System;
namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class FacturaDTO
    {
        public string ID { get; set; } = null!;
        public OrdenDeCompraDTO ID_OrdenDeCompra { get; set; }
    }
}

