using System;
using System.Collections.Generic;

namespace Mvc10_FormCrud.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
