using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PutIncidenteCommand : Command<IncidenteDTO>
{
    private IncidenteDTO _incidente;

    public PutIncidenteCommand(IncidenteDTO incidente)
    {
        _incidente = incidente;
    }

    public override void Execute()
    {
        var dao = IncidenteDAOFactory.CreateIncidenteDao();
        dao.Update(IncidenteMapper.DtoToEntity(_incidente));
        SetResult(_incidente);
    }
}