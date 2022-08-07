using System;
using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes
{
    public class CreateTallerCommand : Command<TallerDTO>
    {
        private readonly TallerDTO _taller;

        public CreateTallerCommand(TallerDTO taller)
        {
            _taller = taller;
        }


        public override void Execute()
        {
            InsertTallerCommand commandInsert = CommandFactory.createInsertTallerCommand(_taller);
            commandInsert.Execute();
            SetResult(commandInsert.GetResult());
            /*SendProviderQuotationCommand commandSend = CommandFactory.createSendProviderQuotationCommand(_result);
            commandSend.Execute();*/
        }
    }
}

