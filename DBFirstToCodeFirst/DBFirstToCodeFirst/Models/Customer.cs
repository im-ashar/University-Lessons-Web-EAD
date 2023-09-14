using System;
using System.Collections.Generic;

namespace DBFirstToCodeFirst.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? AmountPayable { get; set; }

    public string? SalesLimit { get; set; }

    public string? RegistrationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
