using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities
{
    public class MarcaEntity
    {
        public MarcaEntity()
        {
            PiezaMarca = new HashSet<PiezaMarcaEntity>();
            ProveedorMarca = new HashSet<ProveedorMarcaEntity>();
            Vehiculo = new HashSet<VehiculoEntity>();
        }

        [Key]
        public string Name { get; set; }


        public ICollection<ProveedorMarcaEntity> ProveedorMarca { get; set; }

        public ICollection<PiezaMarcaEntity> PiezaMarca { get; set; }

        public ICollection<VehiculoEntity> Vehiculo { get; set; }
    }
}
