using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PostPolizaCommand : Command<PolizaDTO>
{
    private PolizaDTO _poliza;

    public PostPolizaCommand(PolizaDTO poliza)
    {
        _poliza = poliza;
    }

    public override void Execute()
    {
        var dao = PolizaDAOFactory.CreatePolizaDao();
        dao.Insert(PolizaMapper.DtoToEntity(_poliza));
        SetResult(_poliza);
    }
}