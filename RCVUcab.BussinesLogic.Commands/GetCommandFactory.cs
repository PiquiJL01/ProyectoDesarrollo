using RCVUcab.BussinesLogic.Commands.Commands.Atomics;

namespace RCVUcab.BussinesLogic.Commands;

public static class GetCommandFactory
{
    public static GetTallerByIdCommand CreateGetTallerByIdCommand(string taller)
    {
        return new GetTallerByIdCommand(taller);
    }

    public static GetTalleresCommand CreateGetTalleresCommand()
    {
        return new GetTalleresCommand();
    }

    public static GetTalleresByBrandCommand CreateGetTalleresByBrandCommand(string marca)
    {
        return new GetTalleresByBrandCommand(marca);
    }

    public static GetAdministradoresCommand CreateGetAdministradoresCommand()
    {
        return new GetAdministradoresCommand();
    }

    public static GetCotizacionesCommand CreateGetCotizacionesCommand()
    {
        return new GetCotizacionesCommand();
    }

    public static GetPolizasCommand CreateGetPolizasCommand()
    {
        return new GetPolizasCommand();
    }

    public static GetPolizaCommand CreateGetPolizaCommand(string id)
    {
        return new GetPolizaCommand(id);
    }

    public static GetPropietarosCommand CreateGetPropietarosCommand()
    {
        return new GetPropietarosCommand();
    }

    public static GetPropietarioCommand CreateGetPropietarioCommand(string id)
    {
        return new GetPropietarioCommand(id);
    }

    public static GetProveedoresCommand CreateGetProveedoresCommand()
    {
        return new GetProveedoresCommand();
    }

    public static GetProveedorCommand CreateGetProveedorCommand(string id)
    {
        return new GetProveedorCommand(id);
    }

    public static GetUsuariosCommand CreateGetUsuariosCommand()
    {
        return new GetUsuariosCommand();
    }

    public static GetUsuarioCommand CreateGetUsuarioCommand(string id)
    {
        return new GetUsuarioCommand(id);
    }

    public static GetVehiculosCommand CreateGetVehiculosCommand()
    {
        return new GetVehiculosCommand();
    }

    public static GetVehiculoCommand CreateGetVehiculoCommand(string id)
    {
        return new GetVehiculoCommand(id);
    }

    public static GetIncidentesCommand CreateGetIncidentesCommand()
    {
        return new GetIncidentesCommand();
    }

    public static GetPeritosCommand CreateGetPeritosCommand()
    {
        return new GetPeritosCommand();
    }

    public static GetOrdenesDeCompraCommand CreateGetOrdenesDeCompraCommand()
    {
        return new GetOrdenesDeCompraCommand();
    }
}