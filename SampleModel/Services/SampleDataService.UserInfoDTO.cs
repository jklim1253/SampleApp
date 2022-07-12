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
    public async Task<ICollection<UserInfoDTO>>
      SelectUserInfoDTOs()
    {
      var groupDTOs = await SelectGroupInfoDTOs();
      var users = await SelectUserInfos();

      var userDTOs = users
        .Select(e =>
        new UserInfoDTO()
        {
          UserId = e.UserId,
          UserName = e.UserName,
          Password = e.Password,
          Group = groupDTOs.SingleOrDefault(g => g.GroupId == e.GroupId)
        })
        .ToList();

      return userDTOs;
    }

    public async Task<UserInfoDTO>
      InsertUserInfoDTO(UserInfoDTO infoDTO)
    {
      var info = new UserInfo()
      {
        UserName = infoDTO.UserName,
        Password = infoDTO.Password,
        GroupId = infoDTO.Group?.GroupId
      };

      var createdUser = await InsertUserInfo(info);

      var groups = await SelectGroupInfoDTOs();

      return new UserInfoDTO()
      {
        UserId = createdUser.UserId,
        UserName = createdUser.UserName,
        Password = createdUser.Password,
        Group = groups.SingleOrDefault(g => g.GroupId == createdUser.GroupId)
      };
    }

    public async Task<UserInfoDTO?>
      UpdateUserInfoDTO(int id, UserInfoDTO infoDTO)
    {
      var info = new UserInfo()
      {
        UserId = infoDTO.UserId,
        UserName = infoDTO.UserName,
        Password = infoDTO.Password,
        GroupId = infoDTO.Group?.GroupId
      };

      var updatedUser = await UpdateUserInfo(id, info);
      if (updatedUser == null) return null;

      var groups = await SelectGroupInfoDTOs();

      return new UserInfoDTO()
      {
        UserId = updatedUser?.UserId,
        UserName = updatedUser?.UserName,
        Password = updatedUser?.Password,
        Group = groups.SingleOrDefault(g => g.GroupId == updatedUser?.GroupId)
      };
    }

    public async Task<bool>
      DeleteUserInfoDTO(int id)
    {
      return await DeleteUserInfo(id);
    }
  }
}
