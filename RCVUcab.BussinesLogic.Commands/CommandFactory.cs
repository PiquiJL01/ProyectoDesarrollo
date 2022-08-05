using System;
using RCVUcab.BussinesLogic.Commands.Commands.Atomics;
using RCVUcab.BussinesLogic.Commands.Commands.Composes;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Commands
{
    public class CommandFactory
    {
        public static GetTallerByIdCommand createGetTallerByIdCommand(string taller)
        {
            return new GetTallerByIdCommand(taller);
        }

        public static GetTalleresCommand createGetTalleresCommand()
        {
            return new GetTalleresCommand();
        }

        public static GetTalleresByBrandCommand createGetTalleresByBrandCommand(string marca)
        {
            return new GetTalleresByBrandCommand(marca);
        }

        public static CreateTallerCommand createCreateTallerCommand(TallerEntity taller)
        {
            return new CreateTallerCommand(taller);
        }

        public static InsertTallerCommand createInsertTallerCommand(TallerEntity taller)
        {
            return new InsertTallerCommand(taller);
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

