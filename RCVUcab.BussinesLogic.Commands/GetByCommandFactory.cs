using RCVUcab.BussinesLogic.Commands.Commands.Atomics;

namespace RCVUcab.BussinesLogic.Commands;

public static class GetByCommandFactory
{
    public static GetCotizacionesByIdCommand CreateGetCotizacionesByIdCommand(string id)
    {
        return new GetCotizacionesByIdCommand(id);
    }

    public static GetCotizacionCommand CreateGetCotizacionCommand(string id)
    {
        return new GetCotizacionCommand(id);
    }

    public static GetPolizasByIdCommand CreateGetPolizaByIdCommand(string id)
    {
        return new GetPolizasByIdCommand(id);
    }

    public static GetPropietariosByIdCommand CreateGetPropietariosByIdCommand(string id)
    {
        return new GetPropietariosByIdCommand(id);
    }

    public static GetProveedoresById CreateGetProveedoresById(string id)
    {
        return new GetProveedoresById(id);
    }

    public static GetUsuariosByIdCommand CreateGetUsuariosByIdCommand(string id)
    {
        return new GetUsuariosByIdCommand(id);
    }

    public static GetVehiculosByIDCommand CreateGetVehiculosByIdCommand(string id)
    {
        return new GetVehiculosByIDCommand(id);
    }

    public static GetIncidenteByAdministradorCommand CreateGetIncidenteByAdministradorCommand(string administrador)
    {
        return new GetIncidenteByAdministradorCommand(administrador);
    }

    public static GetIncidentesByIdCommand CreateGetIncidentesByIdCommand(string id)
    {
        return new GetIncidentesByIdCommand(id);
    }

    public static GetOrdenDeCompraByIdCommand CreateGetOrdenDeCompraByIdCommand(string id)
    {
        return new GetOrdenDeCompraByIdCommand(id);
    }
}