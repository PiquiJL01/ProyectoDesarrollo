using System.Collections.Generic;
using System.Security.Principal;


namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class OrdenDeCompra
    {
        public string ID { get; set; }
        public string Id_Administrador { get; set; }
        public Cotizacion Id_Cotizacion { get; set; }
        public Administrador Administrador { get; set; }
    }
}
