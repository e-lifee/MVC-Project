using Microsoft.EntityFrameworkCore;
using FE.Models.Domain;

namespace FE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StyleAdvisor> Advisor { get; set; }
    }
}
