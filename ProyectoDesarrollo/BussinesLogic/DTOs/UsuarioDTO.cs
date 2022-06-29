using System;
namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class UsuarioDTO
    {
        public enum RolName
        {
            Administrador,
            U_Taller,
            U_Proveedor,
            Perito
        }

        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public RolName Rol { get; set; }
    }
}

