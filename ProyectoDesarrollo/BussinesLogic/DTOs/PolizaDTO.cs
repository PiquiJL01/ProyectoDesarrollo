using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class PolizaDTO
    {
        public enum Tipo
        {
            TodoIncluido,
            SoloAsegurado,
            SoloTerceros
        }

        public string ID { get; set; } = null!;
        [Required]
        public Tipo TipoPoliza { get; set; }
        public string Id_Admin { get; set; }

        public AdministradorDTO Administrador { get; set; } = null!;

        public List<PropietarioDTO> Propietario { get; set; }
    }
}

