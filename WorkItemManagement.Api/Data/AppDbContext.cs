using Microsoft.EntityFrameworkCore;
using WorkItemManagement.Api.Models;


namespace WorkItemManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}