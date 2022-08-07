using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class DeleteCotizacionCommand : Command<CotizacionDTO>
{
    private CotizacionDTO _cotizacion;

    public DeleteCotizacionCommand(CotizacionDTO cotizacion)
    {
        _cotizacion = cotizacion;
    }

    public override void Execute()
    {
        var dao = CotizacionDAOFactory.CreateCotizacionDao();
        dao.Delete(CotizacionMapper.DtoToEntity(_cotizacion));
        SetResult(_cotizacion);
    }
}