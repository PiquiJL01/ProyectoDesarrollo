using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class AdministradorEntity : UsuarioEntity
    {


        public AdministradorEntity()
        {
            Poliza = new HashSet<PolizaEntity>();
            Incidente = new HashSet<IncidenteEntity>();
            OrdenDeCompra  = new HashSet<OrdenDeCompraEntity>();

        }

        public string Id_Admin { get; set; } = null!;



        public ICollection<PolizaEntity> Poliza { get; set; }
        public ICollection<IncidenteEntity> Incidente { get; set; }
        public ICollection<OrdenDeCompraEntity> OrdenDeCompra { get; set; }
        public string ID { get; internal set; }
    }
}

