namespace RCVUcab.Persistence.Entities
{
    public class PiezaCotizacionEntity
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Cotizacion { get; set; }
        public float Precio { get; set; }

        public PiezaEntity Pieza { get; set; }
        public CotizacionEntity Cotizacion { get; set; }
    }
}
