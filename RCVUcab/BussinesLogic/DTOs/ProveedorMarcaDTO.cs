namespace RCVUcab.BussinesLogic.DTOs
{
    public class ProveedorMarcaDTO
    {
        public string ID { get; set; }
        public string Id_Proveedor { get; set; }
        public string Id_Marca { get; set; }
        public string Id_Taller { get; set; }

        public ProveedorDTO Proveedor { get; set; }
        public MarcaDTO Marca { get; set; }
        public TallerDTO Taller { get; set; }
    }
}

