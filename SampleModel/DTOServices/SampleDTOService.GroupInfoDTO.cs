using Microsoft.EntityFrameworkCore;
using SampleModel.DTO;
using SampleModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.DTOServices
{
  public partial class SampleDTOService
  {
    public async Task<ICollection<GroupInfoDTO>>
      SelectGroupInfoDTOs()
    {
      var viewinfos = await dbAccess.SelectViewInfos();

      // normal views
      var views = viewinfos.Select(e =>
        new ViewInfoDTO()
        {
          ViewId = e.ViewId ?? 0,
          ViewName = e.ViewName ?? ""
        })
        .ToList();

      // views for admin
      var adminViews = viewinfos
        .Select(e =>
        new ViewInfoDTO()
        {
          ViewId = e.ViewId ?? 0,
          ViewName = e.ViewName ?? "",
          CanRead = true,
          CanInsert = true,
          CanUpdate = true,
          CanDelete = true
        })
        .ToList();

      var groupinfos = await dbAccess.SelectGroupInfos();
      var groups = groupinfos
        .Select(e =>
        new GroupInfoDTO()
        {
          GroupId = e.GroupId,
          GroupName = e.GroupName,
          Views = e.GroupId == 1 ? adminViews : views
        })
        .ToList();

      return groups;
    }

    public async Task<GroupInfoDTO?>
      SelectGroupInfoDTO(int? id)
    {
      if (id == null) return null;

      var viewinfos = await dbAccess.SelectViewInfos();
      var views = viewinfos
        .Select(e =>
        new ViewInfoDTO()
        {
          ViewId = e.ViewId?? 0,
          ViewName = e.ViewName?? ""
        })
        .ToList();

      var groupinfos = await dbAccess.SelectGroupInfos();
      var info = groupinfos
        .Where(e => e.GroupId == id)
        .Select(e =>
        new GroupInfoDTO()
        {
          GroupId = e.GroupId,
          GroupName = e.GroupName,
          Views = views
        })
        .SingleOrDefault();

      return info;
    }

    public async Task<GroupInfoDTO?>
      InsertGroupInfoDTO(GroupInfoDTO inputDTO)
    {
      var info = new GroupInfo()
      {
        GroupId = inputDTO.GroupId,
        GroupName = inputDTO.GroupName
      };

      // TODO: insert group-view relation
      var createdInfo = await dbAccess.InsertGroupInfo(info);

      var createdInfoDTO = new GroupInfoDTO()
      {
        GroupId = createdInfo.GroupId,
        GroupName = createdInfo.GroupName
      };

      return createdInfoDTO;
    }

    public async Task<GroupInfoDTO?>
      UpdateGroupInfoDTO(int id, GroupInfoDTO inputDTO)
    {
      var info = new GroupInfo()
      {
        GroupId = inputDTO.GroupId,
        GroupName = inputDTO.GroupName
      };

      // TODO: update group-view relation
      var updatedInfo = await dbAccess.UpdateGroupInfo(id, info);
      if (updatedInfo == null) return null;

      var updatedInfoDTO = new GroupInfoDTO()
      {
        GroupId = updatedInfo.GroupId,
        GroupName = updatedInfo.GroupName
      };

      return updatedInfoDTO;
    }

    public async Task<int>
      DeleteGroupInfoDTO(int id)
    {
      // TODO: delete group-view relation

      if (await dbAccess.DeleteGroupInfo(id))
        return 1;

      return 0;
    }
  }
}
