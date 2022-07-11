using Microsoft.EntityFrameworkCore;
using SampleModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public partial class DatabaseService
  {
    public async Task<ICollection<UserInfo>>
      SelectUserInfos()
    {
      using (var context = provider.GetSampleContext())
      {
        var users = await context.UserInfos.ToListAsync();

        return users;
      }
    }

    public async Task<UserInfo?>
      SelectUserInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var user = await context.UserInfos.SingleOrDefaultAsync(e => e.UserId == id);
        return user;
      }
    }

    public async Task<UserInfo>
      InsertUserInfo(UserInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var createdUser = await context.UserInfos.AddAsync(info);
        await context.SaveChangesAsync();

        return createdUser.Entity;
      }
    }

    public async Task<UserInfo?>
      UpdateUserInfo(int id, UserInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.UserInfos.SingleOrDefaultAsync(e => e.UserId == id);
        if (target == null) return null;

        target.UserName = info.UserName;
        target.Password = info.Password;
        target.GroupId = info.GroupId;

        context.Entry(target).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return target;
      }
    }

    public async Task<bool>
      DeleteUserInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.UserInfos.SingleOrDefaultAsync(e => e.UserId == id);
        if (target == null) return false;

        context.UserInfos.Remove(target);
        await context.SaveChangesAsync();

        return true;
      }
    }
  }
}
