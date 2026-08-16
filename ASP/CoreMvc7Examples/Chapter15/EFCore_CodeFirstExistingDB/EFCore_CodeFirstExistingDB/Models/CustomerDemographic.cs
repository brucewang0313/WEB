using System;
using System.Collections.Generic;

namespace EFCore_CodeFirstExistingDB.Models;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; }

    public string CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
