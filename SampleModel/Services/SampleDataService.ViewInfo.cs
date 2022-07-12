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
    public async Task<ICollection<ViewInfo>>
      SelectViewInfos()
    {
      using (var context = provider.GetSampleContext())
      {
        var viewinfos = await context.ViewInfos.ToListAsync();

        return viewinfos;
      }
    }

    public async Task<ViewInfo?>
      SelectViewInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var viewinfo = await context.ViewInfos.SingleOrDefaultAsync(e => e.ViewId == id);

        return viewinfo;
      }
    }

    public async Task<ViewInfo>
      InsertViewInfo(ViewInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var createdInfo = await context.ViewInfos.AddAsync(info);
        await context.SaveChangesAsync();

        return createdInfo.Entity;
      }
    }

    public async Task<ViewInfo?>
      UpdateViewInfo(int id, ViewInfo info)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.ViewInfos.SingleOrDefaultAsync(e => e.ViewId == id);
        if (target == null) return null;

        target.ViewName = info.ViewName;

        context.Entry(target).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return target;
      }  
    }

    public async Task<int>
      DeleteViewInfo(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.ViewInfos.SingleOrDefaultAsync(e => e.ViewId == id);
        if (target == null) return 0;

        context.ViewInfos.Remove(target);
        await context.SaveChangesAsync();

        return 1;
      }
    }
  }
}
