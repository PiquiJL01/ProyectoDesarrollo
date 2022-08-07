using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetPolizasCommand : Command<List<PolizaDTO>>
{
    public override void Execute()
    {
        var dao = PolizaDAOFactory.CreatePolizaDao();
        SetResult(PolizaMapper.ListEntityToDtos(dao.Select()));
    }
}