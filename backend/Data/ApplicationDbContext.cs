using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Api.Models;

namespace SchedulingSystem.Api.Data
{
  public class ApplicationDbContext : DbContext 
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
  }
}
