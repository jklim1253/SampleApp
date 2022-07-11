using Microsoft.EntityFrameworkCore;
using SampleModel.Entity;

namespace SampleModel
{
  public class SampleContext : DbContext
  {
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<GroupInfo> GroupInfos { get; set; }
    public DbSet<ViewInfo> ViewInfos { get; set; }
    public DbSet<GroupViewRelation> GroupViewRelations { get; set; }

    public SampleContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder
        .Entity<GroupViewRelation>(entity =>
        {
          entity.HasKey(e => new { e.GroupId, e.ViewId });
        });
    }
  }
}