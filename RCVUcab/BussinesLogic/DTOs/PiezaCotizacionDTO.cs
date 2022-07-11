namespace RCVUcab.BussinesLogic.DTOs
{
    public class PiezaCotizacionDTO
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Cotizacion { get; set; }
        public float Precio { get; set; }

        public PiezaDTO Pieza { get; set; }
        public CotizacionDTO Cotizacion { get; set; }
    }
}

