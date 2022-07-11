using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Entity
{
  [Table("tbl_groupinfos")]
  public class GroupInfo
  {
    [Key]
    [Column("groupid")]
    public int? GroupId { get; set; }

    [Column("groupname")]
    public string? GroupName { get; set; } = string.Empty;
  }
}
