using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Poliza
    {
        public enum Tipo
        {
            TodoIncluido,
            SoloAsegurado,
            SoloTerceros
        }


        public Poliza()
        {
            Propietario = new HashSet<Propietario>();
        }


        public string ID { get; set; } = null!;
        [Required]
        public Tipo TipoPoliza { get; set; }
        public string Id_Admin { get; set; }


        /*[Required]
        public Propietario Propietario { get; set; }*/


        public Administrador Administrador { get; set; } = null!;

        public ICollection<Propietario> Propietario { get; set; }
    }
}
