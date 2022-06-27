using System;
namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class ProveedorMarcaDTO
    {
        public string ID { get; set; }
        public string Id_Proveedor { get; set; }
        public string Id_Marca { get; set; }

        public ProveedorDTO Proveedor { get; set; }
        public MarcaDTO Marca { get; set; }
    }
}

