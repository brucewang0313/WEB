using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BizDataLibrary.Models;

[Table("Procurement")]
public partial class Procurement
{
    /// <summary>
    /// 進貨單號，自動增加，不可重複
    /// </summary>
    [Key]
    public int ProcurementId { get; set; }

    /// <summary>
    /// 所採購的貨品編號
    /// </summary>
    [StringLength(10)]
    public string PartNo { get; set; } = null!;

    /// <summary>
    /// 進貨日期
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime PurchasingDay { get; set; }

    /// <summary>
    /// 採購數量
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// 進貨單價
    /// </summary>
    public int UintPrice { get; set; }

    /// <summary>
    /// 庫存數量
    /// </summary>
    public int InvetoryQuantity { get; set; }
}
