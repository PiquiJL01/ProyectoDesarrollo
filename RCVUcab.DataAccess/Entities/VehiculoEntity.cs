using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.DataAccess.Entities
{
    public class VehiculoEntity
    {
        public VehiculoEntity()
        {
            VehiculoIncidenteTaller = new HashSet<VehiculoIncidenteTallerEntity>();
        }


        [Key]
        public string Placa { get; set; }
        /*[Required]
        public Marca Marca { get; set; }*/
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string SerialCarroceria { get; set; }
        [Required]
        public int Año { get; set; }
        /*[Required]
        public Propietario Propietario { get; set; }*/
        [Required]
        public int Peso { get; set; }
        [Required]
        public int NumeroDeEjes { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int NumeroDePuestos { get; set; }
        public string Id_Propietario { get; set; }
        public string Id_Marca { get; set; }


        public MarcaEntity Marca { get; set; } = null!;

        public PropietarioEntity Propietario { get; set; } = null;


        public ICollection<VehiculoIncidenteTallerEntity> VehiculoIncidenteTaller { get; set; }
    }
}
