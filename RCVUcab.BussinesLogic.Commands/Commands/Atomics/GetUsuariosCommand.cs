using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Atomics;

public class GetUsuariosCommand : Command<List<UsuarioDTO>>
{
    public override void Execute()
    {
        var dao = UsuarioDAOFactory.CreateUsuarioDao();
        SetResult(UsuarioMapper.ListEntityToDtos(dao.Select()));
    }
}