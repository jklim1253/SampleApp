namespace SampleModel.DTO
{
  public class GroupInfoDTO
  {
    public int? GroupId { get; set; }
    public string? GroupName { get; set; }
    public ICollection<ViewInfoDTO> Views { get; set; } = new List<ViewInfoDTO>();

    public override bool Equals(object? obj)
    {
      return GroupId == (obj as GroupInfoDTO)?.GroupId;
    }

    public override int GetHashCode()
    {
      return GroupId ?? 0;
    }
  }
}