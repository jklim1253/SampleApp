using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Entity
{
  [Table("tbl_viewinfos")]
  public class ViewInfo
  {
    [Key]
    [Column("viewid")]
    public int ViewId { get; set; }

    [Column("viewname")]
    public string ViewName { get; set; }
  }
}
