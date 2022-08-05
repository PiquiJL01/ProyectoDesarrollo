using System;

namespace RCVUcab.Persistence.Entities;

public class QuotationDetailEntity : BaseEntity
{
    public int Quantity
    {
        get; set;
    }

    public decimal Price
    {
        get; set;
    }

    public Guid PartId
    {
        get; set;
    }

    public string ProviderPartType
    {
        get; set;
    }

    public string ProviderPartNumber
    {
        get; set;
    }

    public string PartName
    {
        get; set;
    }

    public decimal Discount
    {
        get; set;
    }

    public string Observation
    {
        get; set;
    }

    public Guid QuotationId
    {
        get; set;
    }

    public QuotationEntity Quotation
    {
        get; set;
    }
}