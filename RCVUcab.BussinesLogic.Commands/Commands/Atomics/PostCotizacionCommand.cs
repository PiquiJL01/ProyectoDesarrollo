using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PostCotizacionCommand : Command<CotizacionDTO>
{
    private CotizacionDTO _cotizacion;

    public PostCotizacionCommand(CotizacionDTO cotizacion)
    {
        _cotizacion = cotizacion;
    }

    public override void Execute()
    {
        var dao = CotizacionDAOFactory.CreateCotizacionDao();
        dao.Insert(CotizacionMapper.DtoToEntity(_cotizacion));
        SetResult(_cotizacion);
    }
}