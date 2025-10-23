namespace SchedulingSystem.Api.Models
{
  public class Service
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empity;
    public decimal Price { get; set; }
    public int DurationInMinutes { get; set; }
  }
}
