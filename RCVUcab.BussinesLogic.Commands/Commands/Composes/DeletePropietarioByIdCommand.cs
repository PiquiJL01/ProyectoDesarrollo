using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeletePropietarioByIdCommand : Command<PropietarioDTO>
{
    private string _id;

    public DeletePropietarioByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = GetCommandFactory.CreateGetPropietarioCommand(_id);
        command1.Execute();
        var command2 = DeleteCommandFactory.CreateDeletePropietarioCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}