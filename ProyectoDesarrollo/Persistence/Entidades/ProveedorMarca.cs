using System;
namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class ProveedorMarca
    {
            public string ID { get; set; }
            public string Id_Proveedor { get; set; }
            public string Id_Marca { get; set; }

            public Proveedor Proveedor { get; set; }
            public Marca Marca { get; set; }

    }
}
