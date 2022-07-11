namespace RCVUcab.Persistence.Entities
{
    public class FacturaEntity
    {
        public string ID { get; set; } = null!;
        public OrdenDeCompraEntity ID_OrdenDeCompra { get; set; }
    }
}
