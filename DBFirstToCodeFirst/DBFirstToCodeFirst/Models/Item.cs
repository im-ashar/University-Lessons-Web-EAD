using System;
using System.Collections.Generic;

namespace DBFirstToCodeFirst.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string? Description { get; set; }

    public string? Price { get; set; }

    public string? Quantity { get; set; }

    public string? CreationDate { get; set; }

    public string? UpdateDate { get; set; }

    public virtual ICollection<SaleLineItem> SaleLineItems { get; } = new List<SaleLineItem>();
}
