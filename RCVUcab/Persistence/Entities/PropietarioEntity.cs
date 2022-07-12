using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class PropietarioEntity
    {

        public PropietarioEntity()
        {
            Vehiculo = new HashSet<VehiculoEntity>();
        }

        [Key]
        public string CedulaRif { get; set; } = null!;
        [Required]
        public string PrimerNombre { get; set; } = null!;
        public string SegundoNombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; } = null!;
        public string Id_Poliza { get; set; } = null!;


        public PolizaEntity Poliza { get; set; } = null!;

        public ICollection<VehiculoEntity> Vehiculo { get; set; }
    }
}
