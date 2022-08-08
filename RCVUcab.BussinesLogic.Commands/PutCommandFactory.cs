using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands;

public class PutCommandFactory
{
    public static PutCotizacionCommand CreatePutCotizacionCommand(CotizacionDTO cotizacion)
    {
        return new PutCotizacionCommand(cotizacion);
    }

    public static PutPolizaCommand CreatePutPolizaCommand(PolizaDTO poliza)
    {
        return new PutPolizaCommand(poliza);
    }

    public static PutTallerCommand CreatePutTallerCommand(TallerDTO taller)
    {
        return new PutTallerCommand(taller);
    }

    public static PutPropietarioCommand CreatePutPropietarioCommand(PropietarioDTO propietario)
    {
        return new PutPropietarioCommand(propietario);
    }

    public static PutProveedorCommand CreatePutProveedorCommand(ProveedorDTO proveedor)
    {
        return new PutProveedorCommand(proveedor);
    }

    public static PutUsuarioCommand CreatePutUsuarioCommand(UsuarioDTO usuario)
    {
        return new PutUsuarioCommand(usuario);
    }

    public static PutVehiculoCommand CreatePutVehiculoCommand(VehiculoDTO vehiculo)
    {
        return new PutVehiculoCommand(vehiculo);
    }

    public static PutIncidenteCommand CreatePutIncidenteCommand(IncidenteDTO incidente)
    {
        return new PutIncidenteCommand(incidente);
    }

    public static PutOrdeDeCompraCommand CreatePutOrdeDeCompraCommand(OrdenDeCompraDTO ordenDeCompra)
    {
        return new PutOrdeDeCompraCommand(ordenDeCompra);
    }
}