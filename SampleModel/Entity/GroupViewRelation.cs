using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Entity
{
  [Table("tbl_group_view_relations")]
  public class GroupViewRelation
  {
    [Column("groupid")]
    public int GroupId { get; set; }

    [Column("viewid")]
    public int ViewId { get; set; }

    [Column("canread")]
    public bool CanRead { get; set; }

    [Column("caninsert")]
    public bool CanInsert { get; set; }

    [Column("canupdate")]
    public bool CanUpdate { get; set; }

    [Column("candelete")]
    public bool CanDelete { get; set; }
  }
}
