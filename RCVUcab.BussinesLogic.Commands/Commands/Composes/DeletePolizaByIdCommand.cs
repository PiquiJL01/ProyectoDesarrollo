using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeletePolizaByIdCommand : Command<PolizaDTO>
{
    private string _id;

    public DeletePolizaByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = GetCommandFactory.CreateGetPolizaCommand(_id);
        command1.Execute();
        var command2 = DeleteCommandFactory.CreatedDeletePolizaCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}