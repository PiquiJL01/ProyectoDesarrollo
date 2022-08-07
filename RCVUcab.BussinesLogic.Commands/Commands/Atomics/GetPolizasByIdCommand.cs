using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetPolizasByIdCommand : Command<List<PolizaDTO>>
{
    private string _id;

    public GetPolizasByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = PolizaDAOFactory.CreatePolizaDao();
        SetResult(PolizaMapper.ListEntityToDtos(dao.Select()));
    }
}