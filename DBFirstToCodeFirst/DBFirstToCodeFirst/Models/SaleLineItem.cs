using System;
using System.Collections.Generic;

namespace DBFirstToCodeFirst.Models;

public partial class SaleLineItem
{
    public int LineNo { get; set; }

    public int? SaleId { get; set; }

    public int? ItemId { get; set; }

    public string? Quantity { get; set; }

    public int? Amount { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Sale? Sale { get; set; }
}
