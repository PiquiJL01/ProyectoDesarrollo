using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetPropietariosByIdCommand : Command<List<PropietarioDTO>>
{
    private string _id;

    public GetPropietariosByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        SetResult(PropietarioMapper.ListEntityToDtos(dao.GetPropietarioByID(_id)));
    }
}