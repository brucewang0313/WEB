using System;
using System.Collections.Generic;

namespace Mvc7_NorthwindPagination.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}
