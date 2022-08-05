using RCVUcab.BussinesLogic.Commands.Atomics;
using RCVUcab.BussinesLogic.Commands.Composes;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.BussinesLogic.Commands;

public static class CommandFactory
{
    public static GetProvidersByBrandCommand createGetProvidersByBrandCommand(string brand)
    {
        return new GetProvidersByBrandCommand(brand);
    }

    public static CreateProviderQuotationCommand createCreateProviderQuotationCommand(QuotationEntity quotation)
    {
        return new CreateProviderQuotationCommand(quotation);
    }

    public static InsertProviderQuotationCommand createInsertProviderQuotationCommand(QuotationEntity quotation)
    {
        return new InsertProviderQuotationCommand(quotation);
    }

    public static SendProviderQuotationCommand createSendProviderQuotationCommand(QuotationDTO quotation)
    {
        return new SendProviderQuotationCommand(quotation);
    }
}