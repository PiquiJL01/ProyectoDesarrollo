using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands;

public static class PostCommandFactory
{
    public static PostTallerCommand CreatePostTallerCommand(TallerDTO taller)
    {
        return new PostTallerCommand(taller);
    }

    public static PostIncidenteCommand CreatePostIncidenteCommand(IncidenteDTO incidente)
    {
        return new PostIncidenteCommand(incidente);
    }

    public static PostPolizaCommand CreatePostPolizaCommand(PolizaDTO poliza)
    {
        return new PostPolizaCommand(poliza);
    }

    public static PostPropietarioCommand CreatePostPropietarioCommand(PropietarioDTO propietario)
    {
        return new PostPropietarioCommand(propietario);
    }

    public static PostProveedorCommand CreatePostProveedorCommand(ProveedorDTO proveedor)
    {
        return new PostProveedorCommand(proveedor);
    }

    public static PostUsuarioCommand CretaePostUsuarioCommand(UsuarioDTO usuario)
    {
        return new PostUsuarioCommand(usuario);
    }

    public static PostVehiculoCommand CreatePostVehiculoCommand(VehiculoDTO vehiculo)
    {
        return new PostVehiculoCommand(vehiculo);
    }

    public static PostCotizacionCommand CreatePostCotizacionCommand(CotizacionDTO cotizacion)
    {
        return new PostCotizacionCommand(cotizacion);
    }
}