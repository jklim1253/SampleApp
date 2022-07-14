using Microsoft.EntityFrameworkCore;
using SampleModel.DTO;
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
    public async Task<ICollection<GroupInfoDTO>>
      SelectGroupInfoDTOs()
    {
      using (var context = provider.GetSampleContext())
      {
        var views = await context.ViewInfos
          .Select(e =>
          new ViewInfoDTO()
          {
            ViewId = e.ViewId?? 0,
            ViewName = e.ViewName?? ""
          })
          .ToListAsync();

        var adminViews = await context.ViewInfos
          .Select(e =>
          new ViewInfoDTO()
          {
            ViewId = e.ViewId?? 0,
            ViewName = e.ViewName?? "",
            CanRead = true,
            CanInsert = true,
            CanUpdate = true,
            CanDelete = true
          })
          .ToListAsync();

        var groups = await context.GroupInfos
          .Select(e =>
          new GroupInfoDTO()
          {
            GroupId = e.GroupId,
            GroupName = e.GroupName,
            Views = e.GroupId == 1? adminViews : views
          })
          .ToListAsync();

        return groups;
      }
    }

    public async Task<GroupInfoDTO?>
      SelectGroupInfoDTO(int? id)
    {
      if (id == null) return null;

      using (var context = provider.GetSampleContext())
      {
        var views = await context.ViewInfos
          .Select(e =>
          new ViewInfoDTO()
          {
            ViewId = e.ViewId?? 0,
            ViewName = e.ViewName?? ""
          })
          .ToListAsync();

        var info = await context.GroupInfos
          .Where(e => e.GroupId == id)
          .Select(e =>
          new GroupInfoDTO()
          {
            GroupId = e.GroupId,
            GroupName = e.GroupName,
            Views = views
          })
          .SingleOrDefaultAsync();

        return info;
      }
    }

    public async Task<GroupInfoDTO?>
      InsertGroupInfoDTO(GroupInfoDTO inputDTO)
    {
      var info = new GroupInfo()
      {
        GroupId = inputDTO.GroupId,
        GroupName = inputDTO.GroupName
      };

      using (var context = provider.GetSampleContext())
      {
        var createdInfo = await context.GroupInfos.AddAsync(info);
        await context.SaveChangesAsync();

        var createdInfoDTO = await SelectGroupInfoDTO(createdInfo.Entity.GroupId);

        return createdInfoDTO;
      }
    }

    public async Task<GroupInfoDTO?>
      UpdateGroupInfoDTO(int id, GroupInfoDTO inputDTO)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.GroupInfos.FindAsync(id);
        if (target == null) return null;

        target.GroupName = inputDTO.GroupName;

        context.Entry(target).State = EntityState.Modified;
        await context.SaveChangesAsync();

        var updatedInfoDTO = await SelectGroupInfoDTO(target.GroupId);

        return updatedInfoDTO;
      }
    }

    public async Task<int>
      DeleteGroupInfoDTO(int id)
    {
      using (var context = provider.GetSampleContext())
      {
        var target = await context.GroupInfos.FindAsync(id);
        if (target == null) return 0;

        context.GroupInfos.Remove(target);
        await context.SaveChangesAsync();

        return 1;
      }
    }
  }
}
