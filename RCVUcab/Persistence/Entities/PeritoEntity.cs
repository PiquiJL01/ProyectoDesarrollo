using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class PeritoEntity : UsuarioEntity
    {
        public PeritoEntity()
        {
            Incidente = new HashSet<IncidenteEntity>();
        }

        public string Id_Perito { get; set; }

        public ICollection<IncidenteEntity> Incidente { get; set; }
    }
}

