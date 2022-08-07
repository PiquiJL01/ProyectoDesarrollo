using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PutPropietarioCommand : Command<PropietarioDTO>
{
    private PropietarioDTO _propietario;

    public PutPropietarioCommand(PropietarioDTO propietario)
    {
        _propietario = propietario;
    }

    public override void Execute()
    {
        var dao = PropietarioDAOFactory.CreatePropietarioDao();
        dao.Update(PropietarioMapper.DtoToEntity(_propietario));
        SetResult(_propietario);
    }
}