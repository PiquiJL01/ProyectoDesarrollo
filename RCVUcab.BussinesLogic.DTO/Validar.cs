using System;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.DTO
{
    public static class Validar
    {
        public static bool Rol(UsuarioDTO usuarioDto)
        {
            bool isAdmin = (usuarioDto.Rol == RolUsuario.Administrador);
            bool isPerito = (usuarioDto.Rol == RolUsuario.Perito);
            bool isProveedor = (usuarioDto.Rol == RolUsuario.Proveedor);
            bool isTaller = (usuarioDto.Rol == RolUsuario.Taller);

            if (isAdmin || isPerito || isProveedor || isTaller)
            {
                return true;
            }
            return false;
        }
    }
}

