using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.Persistence.Entities
{
    public class PolizaEntity
    {
        public enum Tipo
        {
            TodoIncluido,
            SoloAsegurado,
            SoloTerceros
        }


        public PolizaEntity()
        {
            Propietario = new HashSet<PropietarioEntity>();
        }


        public string ID { get; set; } = null!;
        [Required]
        public Tipo TipoPoliza { get; set; }
        public string Id_Admin { get; set; }


        /*[Required]
        public Propietario Propietario { get; set; }*/


        public AdministradorEntity Administrador { get; set; } = null!;

        public ICollection<PropietarioEntity> Propietario { get; set; }
    }
}
