using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class DeleteUsuarioCommand : Command<UsuarioDTO>
{
    private UsuarioDTO _usuario;

    public DeleteUsuarioCommand(UsuarioDTO usuario)
    {
        _usuario = usuario;
    }

    public override void Execute()
    {
        var dao = UsuarioDAOFactory.CreateUsuarioDao();
        dao.Delete(UsuarioMapper.DtoToEntity(_usuario));
        SetResult(_usuario);
    }
}