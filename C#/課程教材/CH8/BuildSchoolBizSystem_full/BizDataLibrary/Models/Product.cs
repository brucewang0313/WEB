using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BizDataLibrary.Models;

[Table("Product")]
public partial class Product
{
    /// <summary>
    /// 貨品的料號，不可以重複
    /// </summary>
    [Key]
    [StringLength(10)]
    public string PartNo { get; set; } = null!;

    /// <summary>
    /// 貨品的名稱
    /// </summary>
    [StringLength(50)]
    public string PartName { get; set; } = null!;
}
