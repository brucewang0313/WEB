using System;
using System.Collections.Generic;

namespace Mvc7_QuestionaryModelBinding.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
