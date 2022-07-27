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
    public async Task<ICollection<GroupViewRelation>>
      SelectGroupViewRelations()
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .ToListAsync();

        return relations;
      }
    }

    public async Task<ICollection<GroupViewRelation>>
      SelectGroupViewRelationsByGroupId(int groupId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .Where(r => r.GroupId == groupId)
          .ToListAsync();

        return relations;
      }
    }

    public async Task<ICollection<GroupViewRelation>>
      SelectGroupViewRelationsByViewId(int viewId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .Where(r => r.ViewId == viewId)
          .ToListAsync();

        return relations;
      }
    }

    public async Task<GroupViewRelation?>
      SelectGroupViewRelation(int groupId, int viewId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relation = await context.GroupViewRelations
          .SingleOrDefaultAsync(r => r.GroupId == groupId && r.ViewId == viewId);

        return relation;
      }
    }

    public async Task<bool>
      InsertGroupViewRelations(ICollection<GroupViewRelation> inputRelations)
    {
      using (var context = provider.GetSampleContext())
      {
        await context.GroupViewRelations.AddRangeAsync(inputRelations);
        await context.SaveChangesAsync();

        return true;
      }
    }

    public async Task<GroupViewRelation>
      InsertGroupViewRelation(GroupViewRelation inputRelation)
    {
      using (var context = provider.GetSampleContext())
      {
        var createdItem = await context.GroupViewRelations.AddAsync(inputRelation);
        await context.SaveChangesAsync();

        return createdItem.Entity;
      }
    }

    public async Task<bool>
      UpdateGroupViewRelations(int groupId, ICollection<GroupViewRelation> inputRelations)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .Where(r => r.GroupId == groupId)
          .ToListAsync();

        var updated = relations.Join(inputRelations,
          rls => new { rls.GroupId, rls.ViewId },
          input => new { input.GroupId, input.ViewId },
          (rls, input) =>
          {
            rls.CanRead = input.CanRead;
            rls.CanInsert = input.CanInsert;
            rls.CanUpdate = input.CanUpdate;
            rls.CanDelete = input.CanDelete;

            return rls;
          });

        context.Entry(updated).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return true;
      }
    }

    public async Task<bool>
      DeleteGroupViewRelations(int groupId, int viewId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .SingleOrDefaultAsync(r => r.GroupId == groupId && r.ViewId == viewId);
        if (relations == null) return false;

        context.GroupViewRelations.Remove(relations);
        await context.SaveChangesAsync();

        return true;
      }
    }

    public async Task<bool>
      DeleteGroupViewRelationsByGroupId(int groupId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .Where(r => r.GroupId == groupId)
          .ToListAsync();
        if (relations.Count == 0) return false;

        context.GroupViewRelations.RemoveRange(relations);
        await context.SaveChangesAsync();

        return true;
      }
    }

    public async Task<bool>
      DeleteGroupViewRelationsByViewId(int viewId)
    {
      using (var context = provider.GetSampleContext())
      {
        var relations = await context.GroupViewRelations
          .Where(r => r.ViewId == viewId)
          .ToListAsync();
        if (relations.Count == 0) return false;

        context.GroupViewRelations.RemoveRange(relations);
        await context.SaveChangesAsync();

        return true;
      }
    }
  }
}
