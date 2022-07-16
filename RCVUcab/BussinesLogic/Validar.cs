using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.BussinesLogic;

public static class Validar
{
    public static bool Rol(UsuarioDTO usuarioDto)
    {
        if ((usuarioDto.Rol == RolUsuario.Administrador) 
            || (usuarioDto.Rol == RolUsuario.Perito)
            || (usuarioDto.Rol == RolUsuario.Proveedor)
            || (usuarioDto.Rol == RolUsuario.Taller))
        {
            return true;
        }
        return false;
    }
}