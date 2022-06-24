namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Factura
    {
        public string ID { get; set; } = null!;
        public OrdenDeCompra ID_OrdenDeCompra { get; set; }
    }
}
