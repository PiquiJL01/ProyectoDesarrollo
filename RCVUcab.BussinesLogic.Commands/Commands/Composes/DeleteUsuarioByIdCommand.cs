using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeleteUsuarioByIdCommand : Command<UsuarioDTO>
{
    private string _id;

    public DeleteUsuarioByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = GetCommandFactory.CreateGetUsuarioCommand(_id);
        command1.Execute();
        var command2 = DeleteCommandFactory.CreateDeleteUsuarioCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}