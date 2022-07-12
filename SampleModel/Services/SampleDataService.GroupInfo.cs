using Microsoft.EntityFrameworkCore;
using SampleModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public partial class SampleDataService
  {
    public async Task<ICollection<GroupInfo>>
      SelectGroupInfos()
    {
      using (var context = provider.GetSampleContext())
      {
        var groups = await context.GroupInfos.ToListAsync();
        return groups;
      }
    }

    public async Task<GroupInfo?>
      SelectGroupInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var group = await context.GroupInfos.SingleOrDefaultAsync(e => e.GroupId == id);
        return group;
      }
    }

    public async Task<GroupInfo>
      InsertGroupInfo(GroupInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var createdGroup = await context.GroupInfos.AddAsync(info);
        await context.SaveChangesAsync();

        return createdGroup.Entity;
      }
    }

    public async Task<GroupInfo?>
      UpdateGroupInfo(int id, GroupInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.GroupInfos.SingleOrDefaultAsync(e => e.GroupId == id);
        if (target == null) return null;

        target.GroupName = info.GroupName;

        context.Entry(target).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return target;
      }
    }

    public async Task<bool>
      DeleteGroupInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.GroupInfos.SingleOrDefaultAsync(e => e.GroupId == id);
        if (target == null) return false;

        context.GroupInfos.Remove(target);
        await context.SaveChangesAsync();

        return true;
      }
    }
  }
}
