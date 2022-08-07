using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetIncidentesCommand : Command<List<IncidenteDTO>>
{
    public override void Execute()
    {
        var dao = IncidenteDAOFactory.CreateIncidenteDao();
        SetResult(IncidenteMapper.ListEntityToDtos(dao.Select()));
    }
}