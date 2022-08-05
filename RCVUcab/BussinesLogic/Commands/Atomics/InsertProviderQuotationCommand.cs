using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence;
using RCVUcab.Persistence.DAOs.DB;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.BussinesLogic.Commands.Atomics;

public class InsertProviderQuotationCommand : Command<QuotationDTO>
{
    private readonly QuotationEntity _quotation;
    private QuotationDTO _result;

    public InsertProviderQuotationCommand(QuotationEntity quotation)
    {
        _quotation = quotation;
    }


    public override void Execute()
    {
        ProviderDB dao = ProviderDAOFactory.CreateProviderDB();
        _result = dao.CreateProviderQuotation(_quotation);
    }

    public override QuotationDTO GetResult()
    {
        return _result;
    }
}