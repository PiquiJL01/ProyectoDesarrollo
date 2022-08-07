using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeleteVehiculoByIdCommand : Command<VehiculoDTO>
{
    private string _id;

    public DeleteVehiculoByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = GetCommandFactory.CreateGetVehiculoCommand(_id);
        command1.Execute();
        var command2 = DeleteCommandFactory.CreateDeleteVehiculoCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}