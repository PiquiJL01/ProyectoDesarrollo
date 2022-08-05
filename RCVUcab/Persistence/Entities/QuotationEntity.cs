using System;
using System.Collections.Generic;

namespace RCVUcab.Persistence.Entities;

public class QuotationEntity : BaseEntity
{
    public int QuotationNumber
    {
        get; set;
    }

    public Guid ProviderId
    {
        get; set;
    }

    public string WorkshopPhone
    {
        get; set;
    }

    public string WorkshopAddress
    {
        get; set;
    }

    public string WorkshopName
    {
        get; set;
    }

    public Guid WorkshopProviderId
    {
        get; set;
    }

    public string Observation
    {
        get; set;
    }

    public string SellerName
    {
        get; set;
    }

    public Guid InvitationId
    {
        get; set;
    }

    public ICollection<QuotationDetailEntity> Quotations
    {
        get; set;
    }
}