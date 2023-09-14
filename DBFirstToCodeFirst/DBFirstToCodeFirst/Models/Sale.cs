using System;
using System.Collections.Generic;

namespace DBFirstToCodeFirst.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? CustomerId { get; set; }

    public string? Date { get; set; }

    public string? Status { get; set; }

    public string? AmountPaid { get; set; }

    public string? AmountLeft { get; set; }

    public string? TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Receipt> Receipts { get; } = new List<Receipt>();

    public virtual ICollection<SaleLineItem> SaleLineItems { get; } = new List<SaleLineItem>();
}
