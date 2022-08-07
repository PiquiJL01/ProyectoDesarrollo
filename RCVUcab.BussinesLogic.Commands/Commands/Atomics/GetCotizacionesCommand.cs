using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetCotizacionesCommand : Command<List<CotizacionDTO>>
{
    public override void Execute()
    {
        var dao = CotizacionDAOFactory.CreateCotizacionDao();
        SetResult(CotizacionMapper.ListEntityToDtos(dao.Select()));
    }
}