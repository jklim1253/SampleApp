using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.DTO
{
  public class UserInfoDTO
  {
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public GroupInfoDTO? Group { get; set; }

    public override bool Equals(object? obj)
    {
      return UserId == (obj as UserInfoDTO)?.UserId;
    }

    public override int GetHashCode()
    {
      return UserId?? 0;
    }
  }
}
