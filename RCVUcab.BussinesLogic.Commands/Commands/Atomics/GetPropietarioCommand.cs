using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;
using RCVUcab.DataAccess.DAOs.Implementations;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetPropietarioCommand : Command<PropietarioDTO>
{
    private string _id;

    public GetPropietarioCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        SetResult(PropietarioMapper.EntityToDto(dao.Select(_id)));
    }
}