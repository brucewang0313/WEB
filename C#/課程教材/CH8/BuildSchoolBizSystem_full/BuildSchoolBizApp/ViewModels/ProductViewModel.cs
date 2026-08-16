using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchoolBizApp.ViewModels
{
    public class ProductViewModel
    {
        /// <summary>
        /// 貨品的料號，不可以重複
        /// </summary>        
        public string? PartNo { get; set; }

        /// <summary>
        /// 貨品的名稱
        /// </summary>
        public string? PartName { get; set; }

        public string DisplayName => $"{PartNo} - {PartName}";
    }
}
