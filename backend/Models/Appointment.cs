using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingSystem.Api.Models
{
  public class Appointment
  {
    public int Id { get; set; }

    public int ClientId { get; set; }
    [ForeignKey("ClientId")]
    public client? Client { get; set; }

    public int ServiceId { get; set; }
    [ForeignKey("ServiceId")]
    public Service? Service { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public string Status { get; set; } = "Scheduled";
  }
}
