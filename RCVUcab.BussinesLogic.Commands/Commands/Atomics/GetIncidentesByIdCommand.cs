using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetIncidentesByIdCommand : Command<List<IncidenteDTO>>
{
    private string _id;

    public GetIncidentesByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = IncidenteDAOFactory.CreateIncidenteDao();
        SetResult(IncidenteMapper.ListEntityToDtos(dao.GetIncidenteByID(_id)));
    }
}