using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.ViewModels
{
    public class ProductViewModel
    {
        public string? PartNo { get; set; }// 貨品料號，不可重複

        public string? PartName { get; set; }// 貨品名稱

        public string DisplayName => $"{PartNo}-{PartName}";
    }
}
