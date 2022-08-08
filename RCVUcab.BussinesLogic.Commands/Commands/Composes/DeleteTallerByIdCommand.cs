using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes
{
    public class DeleteTallerByIdCommand : Command<TallerDTO>
    {
        private string _id;

        public DeleteTallerByIdCommand(string id)
        {
            _id = id;
        }

        public override void Execute()
        {
            var command1 = GetCommandFactory.CreateGetTallerByIdCommand(_id);
            command1.Execute();
            var command2 = DeleteCommandFactory.CreateDeleteTallerCommand(command1.GetResult());
            command2.Execute();
            SetResult(command2.GetResult());
        }
    }
}

