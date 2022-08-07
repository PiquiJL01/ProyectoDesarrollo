using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOFactory;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeleteProveedorByIdCommand : Command<ProveedorDTO>
{
    private string _id;

    public DeleteProveedorByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = CommandFactory.CreateGetProveedorCommand(_id);
        command1.Execute();
        var command2 = CommandFactory.CreateDeleteProveedorCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}