using System;
using System.Collections.Generic;

namespace Mvc7_QuestionaryModelBinding.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
