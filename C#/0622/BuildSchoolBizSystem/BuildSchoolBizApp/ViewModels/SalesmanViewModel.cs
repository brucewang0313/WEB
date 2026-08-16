using System;
using System.Collections.Generic;
using System.Text;

namespace BuildSchoolBizApp.ViewModels
{
    public class SalesmanViewModel
    {
        public int JobNumber { get; set; }
        public string? Name { get; set; }

        public string? DisplayName => $"{JobNumber}-{Name}";
    }
}
