using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes;

public class DeleteCotizacionByIdCommand : Command<CotizacionDTO>
{
    private string _id;

    public DeleteCotizacionByIdCommand(string id)
    {
        _id = id;
    }

    public override void Execute()
    {
        var command1 = GetByCommandFactory.CreateGetCotizacionCommand(_id);
        command1.Execute();
        var command2 = DeleteCommandFactory.CreateDeleteCotizacionCommand(command1.GetResult());
        command2.Execute();
        SetResult(command2.GetResult());
    }
}