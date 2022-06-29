using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Perito : Usuario
    {
        public Perito()
        {
            Incidente = new HashSet<Incidente>();
        }

        public string Id_Perito { get; set; }

        public ICollection<Incidente> Incidente { get; set; }
    }
}

