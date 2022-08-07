using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PostPropietarioCommand : Command<PropietarioDTO>
{
    private PropietarioDTO _propietario;

    public PostPropietarioCommand(PropietarioDTO propietario)
    {
        _propietario = propietario;
    }

    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        dao.Insert(PropietarioMapper.DtoToEntity(_propietario));
        SetResult(_propietario);
    }
}