using System;
using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTOs;

public class QuotationDTO
{
    public Guid Id { get; set; }

    public int QuotationNumber { get; set; }

    public Guid OperationId { get; set; }

    public string WorkshopPhone { get; set; }

    public string WorkshopAddress { get; set; }

    public string WorkshopName { get; set; }

    public Guid WorkshopProviderId { get; set; }

    public Guid ProviderId { get; set; }

    public Guid InvitationId { get; set; }

    public string Observation { get; set; }

    public string SellerName { get; set; }

    public ICollection<QuotationDetailDTO> Parts { get; set; }
}