using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchoolBizApp.ViewModels
{
    public class SalesmanViewModel
    {
        public int JobNumber { get; set; }

        public string? Name { get; set; }

        public string? DisplayName => $"{JobNumber} - {Name}";
    }
}
