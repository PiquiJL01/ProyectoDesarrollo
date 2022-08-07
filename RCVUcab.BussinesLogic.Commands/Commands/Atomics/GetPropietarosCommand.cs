using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetPropietarosCommand : Command<List<PropietarioDTO>>
{
    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        SetResult(PropietarioMapper.ListEntityToDtos(dao.Select()));
    }
}