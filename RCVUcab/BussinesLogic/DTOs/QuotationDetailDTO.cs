using System;

namespace RCVUcab.BussinesLogic.DTOs;

public class QuotationDetailDTO
{
    public Guid Id { get; set; }
    public Guid PartId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProviderPartType { get; set; }
    public string ProviderPartNumber { get; set; }
    public string PartName { get; set; }
    public decimal Discount { get; set; }
    public string PartStatus { get; set; }
    public string Observation { get; set; }
}