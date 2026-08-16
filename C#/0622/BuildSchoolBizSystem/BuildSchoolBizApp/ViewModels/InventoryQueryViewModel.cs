using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.ViewModels
{
    public class InventoryQueryViewModel
    {
        public string? PartNo { get; set; }
        public string? PartName { get; set; }
        public int TotalInventoryQuantity { get; set; }
    }
}
