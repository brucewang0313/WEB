using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BizDataLibrary.Models;

[Table("SellingSource")]
public partial class SellingSource
{
    /// <summary>
    /// 作為自動索引，不可重複
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 銷售單編號
    /// </summary>
    public int SellingId { get; set; }

    /// <summary>
    /// 進貨單編號，表示從哪個進貨單出的貨
    /// </summary>
    public int ProcurementId { get; set; }

    /// <summary>
    /// 表示從特定進貨單出了多少貨
    /// </summary>
    public int Quantity { get; set; }
}

