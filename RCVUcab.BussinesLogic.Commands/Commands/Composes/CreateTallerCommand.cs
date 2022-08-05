using System;
using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Commands.Commands.Composes
{
    public class CreateTallerCommand : Command<TallerDTO>
    {
        private readonly TallerEntity _taller;
        private TallerDTO _result;

        public CreateTallerCommand(TallerEntity taller)
        {
            _taller = taller;
        }


        public override void Execute()
        {
            InsertTallerCommand commandInsert = CommandFactory.createInsertTallerCommand(_taller);
            commandInsert.Execute();
            _result = commandInsert.GetResult();
            /*SendProviderQuotationCommand commandSend = CommandFactory.createSendProviderQuotationCommand(_result);
            commandSend.Execute();*/
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }

        public override List<TallerDTO> GetResultList()
        {
            throw new NotImplementedException();
        }
    }
}

