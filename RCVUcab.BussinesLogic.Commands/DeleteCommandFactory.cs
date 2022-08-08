using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTO.DTOs;


namespace RCVUcab.BussinesLogic.Commands;

public class DeleteCommandFactory
{
    public static DeleteCotizacionCommand CreateDeleteCotizacionCommand(CotizacionDTO cotizacion)
    {
        return new DeleteCotizacionCommand(cotizacion);
    }

    public static DeletePolizaCommand CreatedDeletePolizaCommand(PolizaDTO poliza)
    {
        return new DeletePolizaCommand(poliza);
    }

    public static DeletePropietarioCommand CreateDeletePropietarioCommand(PropietarioDTO propietario)
    {
        return new DeletePropietarioCommand(propietario);
    }

    public static DeleteProveedorCommand CreateDeleteProveedorCommand(ProveedorDTO proveedor)
    {
        return new DeleteProveedorCommand(proveedor);
    }

    public static DeleteUsuarioCommand CreateDeleteUsuarioCommand(UsuarioDTO usuario)
    {
        return new DeleteUsuarioCommand(usuario);
    }

    public static DeleteVehiculoCommand CreateDeleteVehiculoCommand(VehiculoDTO vehiculo)
    {
        return new DeleteVehiculoCommand(vehiculo);
    }

    public static DeleteTallerCommand CreateDeleteTallerCommand(TallerDTO taller)
    {
        return new DeleteTallerCommand(taller);
    }
}