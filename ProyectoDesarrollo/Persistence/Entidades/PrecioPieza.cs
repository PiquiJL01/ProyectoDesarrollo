using System.Security.Principal;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class PrecioPieza
    {
        public int ID { get; set; }
        public Pieza Pieza { get; set; }
        public float Precio { get; set; }
    }
}
