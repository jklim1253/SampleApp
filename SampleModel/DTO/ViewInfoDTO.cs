namespace SampleModel.DTO
{
  public class ViewInfoDTO
  {
    public int ViewId { get; set; }
    public string ViewName { get; set; }
    public bool CanRead { get; set; }
    public bool CanInsert { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
  }
}