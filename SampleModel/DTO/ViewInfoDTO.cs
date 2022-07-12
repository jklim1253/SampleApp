namespace SampleModel.DTO
{
  public class ViewInfoDTO
  {
    public int ViewId { get; set; }
    public string ViewName { get; set; } = string.Empty;
    public bool CanRead { get; set; } = false;
    public bool CanInsert { get; set; } = false;
    public bool CanUpdate { get; set; } = false;
    public bool CanDelete { get; set; } = false;
  }
}