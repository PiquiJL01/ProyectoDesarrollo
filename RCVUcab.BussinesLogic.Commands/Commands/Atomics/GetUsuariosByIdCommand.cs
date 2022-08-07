using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetUsuariosByIdCommand : Command<List<UsuarioDTO>>
{
    private string _id;

    public GetUsuariosByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = UsuarioDAOFactory.CreateUsuarioDao();
        SetResult(UsuarioMapper.ListEntityToDtos(dao.GetUsuariosByID(_id)));
    }
}