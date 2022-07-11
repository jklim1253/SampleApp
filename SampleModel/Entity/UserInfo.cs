using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Entity
{
  [Table("tbl_userinfos")]
  public class UserInfo
  {
    [Key]
    [Column("userid")]
    public int? UserId { get; set; }

    [Column("username")]
    [MaxLength(100)]
    public string? UserName { get; set; } = string.Empty;

    [Column("password")]
    [MaxLength(100)]
    public string? Password { get; set; } = string.Empty;

    [Column("groupid")]
    public int? GroupId { get; set; }
  }
}
