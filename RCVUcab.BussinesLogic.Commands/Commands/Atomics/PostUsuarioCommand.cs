using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class PostUsuarioCommand : Command<UsuarioDTO>
{
    private UsuarioDTO _usuarioDTO;

    public PostUsuarioCommand(UsuarioDTO usuarioDTO)
    {
        _usuarioDTO = usuarioDTO;
    }

    public override void Execute()
    {
        var dao = UsuarioDAOFactory.CreateUsuarioDao();
        dao.Insert(UsuarioMapper.DtoToEntity(_usuarioDTO));
        SetResult(_usuarioDTO);
    }
}