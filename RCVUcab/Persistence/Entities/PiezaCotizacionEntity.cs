namespace RCVUcab.Persistence.Entities
{
    public class PiezaCotizacionEntity
    {
        public string ID { get; set; }
        public string Id_Pieza { get; set; }
        public string Id_Cotizacion { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descuento { get; set; }
        //ENUM TiempoEntrega
        public string TiempoDeEntrega { get; set; }
        //ENUM PIEZA ESTATUS
        public string PiezaEstatus { get; set; }


        public PiezaEntity Pieza { get; set; }
        public CotizacionEntity Cotizacion { get; set; }
    }
}
