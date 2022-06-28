using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Administrador : Usuario
    {


        public Administrador()
        {
            Poliza = new HashSet<Poliza>();
            Incidente = new HashSet<Incidente>();
            OrdenDeCompra  = new HashSet<OrdenDeCompra>();

        }

        public string Id_Admin { get; set; } = null!;



        public ICollection<Poliza> Poliza { get; set; }
        public ICollection<Incidente> Incidente { get; set; }
        public ICollection<OrdenDeCompra> OrdenDeCompra { get; set; }
        public string ID { get; internal set; }
    }
}

