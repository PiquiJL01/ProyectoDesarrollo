using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

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
        PolizaDAO dao = PolizaDAOFactory.CreatePolizaDao();
        SetResult(PolizaMapper.EntityToDto(dao.InsertR(PolizaMapper.DtoToEntity(_poliza))));
    }
}