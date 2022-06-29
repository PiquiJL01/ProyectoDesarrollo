using System;
namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class PiezaMarcaDTO
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Marca { get; set; }

        public PiezaDTO Pieza { get; set; }
        public MarcaDTO Marca { get; set; }
    }
}

