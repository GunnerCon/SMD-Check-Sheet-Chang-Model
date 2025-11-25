using Microsoft.EntityFrameworkCore;
using SMDCheckSheet.Models;

namespace SMDCheckSheet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CheckModel> CheckModels { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChangeModel> ChangeModels { get; set; }
        public DbSet<PQCCheck> PQCChecks { get; set; }
        public DbSet<ProgramCheck> ProgramChecks { get; set; }
        public DbSet<StandardProduction> StandardProductions { get; set; }
        public DbSet<StandardVehicle> StandardVehicles { get; set; }
        public DbSet<TimeChangeModel> TimeChangeModels { get; set; }
    }
}
