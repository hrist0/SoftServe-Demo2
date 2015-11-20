using SoftServe.Demo2.Migrations;
using SoftServe.Demo2.Models.EmployeesModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SoftServe.Demo2.Models.EmployeeContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            : base("EmployeeDbContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<EmployeeDbContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}