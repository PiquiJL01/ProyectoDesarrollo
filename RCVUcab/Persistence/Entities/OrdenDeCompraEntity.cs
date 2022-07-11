namespace RCVUcab.Persistence.Entities
{
    public class OrdenDeCompraEntity
    {
        public string ID { get; set; }
        public string Id_Administrador { get; set; }
        public CotizacionEntity Id_Cotizacion { get; set; }
        public AdministradorEntity Administrador { get; set; }
    }
}
