namespace SchedulingSystem.Api.Models
{
  public class Client
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empity;
    public string PhoneNumber { get; set; } = string.Empity;
    public string? Email { get; set; }
  }
}
