using RCVUcab.BussinesLogic.Commands.Commands.Composes;

namespace RCVUcab.BussinesLogic.Commands;

public class DeleteByCommandFactory
{
    public static DeleteCotizacionByIdCommand CreateDeleteCotizacionByIdCommand(string id)
    {
        return new DeleteCotizacionByIdCommand(id);
    }

    public static DeletePolizaByIdCommand CreateDeletePolizaByIdCommand(string id)
    {
        return new DeletePolizaByIdCommand(id);
    }

    public static DeletePropietarioByIdCommand CreateDeletePropietarioByIdCommand(string id)
    {
        return new DeletePropietarioByIdCommand(id);
    }

    public static DeleteProveedorByIdCommand CreateDeleteProveedorByIdCommand(string id)
    {
        return new DeleteProveedorByIdCommand(id);
    }

    public static DeleteUsuarioByIdCommand CreateDeleteUsuarioByIdCommand(string id)
    {
        return new DeleteUsuarioByIdCommand(id);
    }

    public static DeleteVehiculoByIdCommand CreateDeleteVehiculoByIdCommand(string id)
    {
        return new DeleteVehiculoByIdCommand(id);
    }
}