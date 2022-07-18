using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Persistence.Entities
{
    public class PolizaEntity
    {
        public PolizaEntity()
        {
            Propietario = new HashSet<PropietarioEntity>();
        }


        public string ID { get; set; } = null!;
        [Required]
        public string TipoPoliza { get; set; }
        public string Id_Admin { get; set; }

        public UsuarioEntity Administrador { get; set; } = null!;

        public ICollection<PropietarioEntity> Propietario { get; set; }
    }
}
