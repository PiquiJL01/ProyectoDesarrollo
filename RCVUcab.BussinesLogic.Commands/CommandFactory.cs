using System;
using RCVUcab.BussinesLogic.Commands.Commands.Atomics;

namespace RCVUcab.BussinesLogic.Commands
{
    public class CommandFactory
    {
        public static GetTallerByIdCommand createGetTallerByIdCommand(string taller)
        {
            return new GetTallerByIdCommand(taller);
        }

        /*public static CreateProviderQuotationCommand createCreateProviderQuotationCommand(QuotationEntity quotation)
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
        }*/
    }
}

