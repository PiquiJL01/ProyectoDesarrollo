using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetUsuarioCommand : Command<UsuarioDTO>
{
    private string _id;

    public GetUsuarioCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var dao = UsuarioDAOFactory.CreateUsuarioDao();
        SetResult(UsuarioMapper.EntityToDto(dao.Select(_id)));
    }
}