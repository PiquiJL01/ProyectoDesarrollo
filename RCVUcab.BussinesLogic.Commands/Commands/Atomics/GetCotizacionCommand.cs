using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetCotizacionCommand : Command<CotizacionDTO>
{
    private string _id;

    public GetCotizacionCommand(string id)
    {
        _id = id;
    }


    public override void Execute()
    {
        var dao = CotizacionDAOFactory.CreateCotizacionDao();
        SetResult(CotizacionMapper.EntityToDto(dao.Select(_id)));
    }
}