using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class PolizaDTO
    {
        public string ID { get; set; } = null!;
        [Required]
        public string TipoPoliza { get; set; }
        public string Id_Admin { get; set; }

        public UsuarioDTO Administrador { get; set; } = null!;

        public List<PropietarioDTO> Propietario { get; set; }
    }
}

