using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BizDataLibrary.Models
{
    [Table("Selling")]
    public partial class Selling
    {
        /// <summary>
        /// 銷售單編號，自動新增，不可重複
        /// </summary>
        [Key]
        public int SellingId { get; set; }

        /// <summary>
        /// 業務員的員工編號
        /// </summary>
        public int SalesJobNumber { get; set; }

        /// <summary>
        /// 銷售的貨品編號
        /// </summary>
        [StringLength(10)]
        public string PartNo { get; set; } = null!;

        /// <summary>
        /// 銷售日期
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime SellingDay { get; set; }

        /// <summary>
        /// 出貨數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 出貨單價
        /// </summary>
        public int UnitPrice { get; set; }
    }

}
