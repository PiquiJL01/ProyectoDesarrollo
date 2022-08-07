using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class DeletePropietarioCommand : Command<PropietarioDTO>
{
    private PropietarioDTO _propietario;

    public DeletePropietarioCommand(PropietarioDTO propietario)
    {
        _propietario = propietario;
    }

    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        dao.Delete(PropietarioMapper.DtoToEntity(_propietario));
        SetResult(_propietario);
    }
}