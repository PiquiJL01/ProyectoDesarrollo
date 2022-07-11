namespace RCVUcab.Persistence.Entities
{
    public class ProveedorMarcaEntity
    {
            public string ID { get; set; }
            public string Id_Proveedor { get; set; }
            public string Id_Marca { get; set; }

            public ProveedorEntity Proveedor { get; set; }
            public MarcaEntity Marca { get; set; }

    }
}
