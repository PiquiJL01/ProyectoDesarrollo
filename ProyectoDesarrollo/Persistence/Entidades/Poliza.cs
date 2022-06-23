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
        public int ID { get; set; }
        [Required]
        public Tipo TipoPoliza { get; set; }
        [Required]
        public Dueno Dueno { get; set; }
    }
}
