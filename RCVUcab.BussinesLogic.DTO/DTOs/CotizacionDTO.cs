namespace RCVUcab.BussinesLogic.DTO.DTOs
{
    public class CotizacionDTO
    {

        public string Id { get; set; } = null!;
        public double MontoTotal { get; set; }
        public string Id_Proveedor { get; set; }
        public string Id_Incidente { get; set; }
        public string Id_Taller { get; set; }


        public TallerDTO Taller { get; set; }
        public IncidenteDTO Incidente { get; set; }
        public ProveedorDTO Proveedor { get; set; }

        public virtual List<PiezaCotizacionDTO> PiezaCotizacion { get; set; }
    }
}

