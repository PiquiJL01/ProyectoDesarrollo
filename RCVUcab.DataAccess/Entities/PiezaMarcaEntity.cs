namespace RCVUcab.DataAccess.Entities
{
    public class PiezaMarcaEntity
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Marca { get; set; }

        public PiezaEntity Pieza { get; set; }
        public MarcaEntity Marca { get; set; }
    }
}

