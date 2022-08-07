using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetIncidenteByAdministradorCommand : Command<List<IncidenteDTO>>
{
    private string _administrador;

    public GetIncidenteByAdministradorCommand(string administrador)
    {
        _administrador = administrador;
    }

    public override void Execute()
    {
        var dao = IncidenteDAOFactory.CreateIncidenteDao();
        SetResult(IncidenteMapper.ListEntityToDtos(dao.GetIncidentesByAdministrador(_administrador)));
    }
}