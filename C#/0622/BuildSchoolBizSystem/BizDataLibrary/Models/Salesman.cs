using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BizDataLibrary.Models;

[Table("Salesman")]
public partial class Salesman
{
    [Key]
    public int JobNumber { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;
}
