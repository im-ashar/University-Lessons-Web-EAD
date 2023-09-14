using System;
using System.Collections.Generic;

namespace DBFirstToCodeFirst.Models;

public partial class Receipt
{
    public int ReceiptNo { get; set; }

    public string? ReceiptDate { get; set; }

    public int? SaleId { get; set; }

    public string? Amount { get; set; }

    public virtual Sale? Sale { get; set; }
}
