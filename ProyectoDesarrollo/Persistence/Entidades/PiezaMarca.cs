using System;
namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class PiezaMarca
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Marca { get; set; }

        public Pieza Pieza { get; set; }
        public Marca Marca { get; set; }
    }
}

