using RCVUcab.BussinesLogic.Commands.Atomics;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.BussinesLogic.Commands.Composes;

public class CreateProviderQuotationCommand : Command<QuotationDTO>
{
    private readonly QuotationEntity _quotation;
    private QuotationDTO _result;

    public CreateProviderQuotationCommand(QuotationEntity quotation)
    {
        _quotation = quotation;
    }


    public override void Execute()
    {
        InsertProviderQuotationCommand commandInsert = CommandFactory.createInsertProviderQuotationCommand(_quotation);
        commandInsert.Execute();
        _result = commandInsert.GetResult();
        SendProviderQuotationCommand commandSend = CommandFactory.createSendProviderQuotationCommand(_result);
        commandSend.Execute();
    }

    public override QuotationDTO GetResult()
    {
        return _result;
    }
}