using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.ViewModels
{
    public class ProcurementViewModel
    {
        public int ProcurementId { get; set; }
        public string? PartNo { get; set; }
        public DateTime PurchasingDay { get; set; }
        public int Quantity { get; set; }
        public int UintPrice { get; set; }
        public int InvetoryQuantity { get; set; }
    }
}
