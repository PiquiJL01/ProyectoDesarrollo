using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.Models
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
        public Dueño Dueño { get; set; }
    }
}
