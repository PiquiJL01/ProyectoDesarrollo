using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class MarcaDTO
    {
        [Key]
        public string Name { get; set; }


        public List<ProveedorMarcaDTO> ProveedorMarca { get; set; }

        public List<PiezaMarcaDTO> PiezaMarca { get; set; }

        public List<VehiculoDTO> Vehiculo { get; set; }
    }
}

