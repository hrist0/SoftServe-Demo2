namespace SoftServe.Demo2.Migrations
{
    using SoftServe.Demo2.Models.EmployeeContext;
    using SoftServe.Demo2.Models.EmployeesModel;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        // Seed database 
        protected override void Seed(EmployeeDbContext context)
        {
            if (!context.Projects.Any())
            {
                SeedProjects(context);
            }
            if (!context.Teams.Any())
            {
                SeedTeams(context);
            }
            if (!context.Employees.Any())
            {
                SeedEmployees(context);
            }
        }
        // Seed employees method
        private static void SeedEmployees(EmployeeDbContext context)
        {
            var employee = new List<Employee>{
                new Employee
                {
                    Name = "Hristo Antov",
                    Position = Position.Trainee,
                    Salary = 2000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "f0ri@abv.bg",
                    Phone = "0999 99 55 33",
                    Address = "Manastirski livadi",
                    ProjectId = 1,
                    TeamId = 1
                },
                new Employee
                {
                    Name = "Iliqn",
                    Position = Position.Trainee,
                    Salary = 2000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "iliqn@abv.bg",
                    Phone = "0999 11 22 33",
                    Address = "Center",
                    ProjectId = 1,
                    TeamId = 1
                },
                new Employee
                {
                    Name = "Damqn",
                    Position = Position.Trainee,
                    Salary = 2000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "damqn@abv.bg",
                    Phone = "0999 99 88 77",
                    Address = "Center",
                    ProjectId = 1,
                    TeamId = 1
                },
                new Employee
                {
                    Name = "Boris",
                    Position = Position.Trainee,
                    Salary = 2000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "boris@abv.bg",
                    ProjectId = 1,
                    TeamId = 2
                },
                new Employee
                {
                    Name = "Mitko",
                    Position = Position.Trainee,
                    Salary = 2000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "mitko@abv.bg",
                    ProjectId = 1,
                    TeamId = 2
                },
                new Employee
                {
                    Name = "Juliqn",
                    Position = Position.TeamLeader,
                    Salary = 10000,
                    Workplace = "SoftServe Bulgaria",
                    Email = "juliqn@gmail.com",
                    Address = "Sofia",
                    ProjectId = 1,
                    TeamId = 1
                },
                new Employee
                {
                    Name = "Desislav",
                    Position = Position.TeamLeader,
                    Salary = 10000,
                    Workplace = "SoftServe Ukraine",
                    Email = "desislav@gmail.com",
                    Address = "Sofia",
                    ProjectId = 2,
                    TeamId = 3
                },
                new Employee
                {
                    Name = "Vladimir",
                    Position = Position.Junior,
                    Salary = 10000,
                    Workplace = "SoftServe Ukraine",
                    Email = "vladimir@gmail.com",
                    Address = "Ukraine",
                    ProjectId = 2,
                    TeamId = 3
                },
                new Employee
                {
                    Name = "Vitalii",
                    Position = Position.Senior,
                    Salary = 10000,
                    Workplace = "SoftServe Ukraine",
                    Email = "vitalii@gmail.com",
                    Address = "Ukraine",
                    ProjectId = 2,
                    TeamId = 3
                },
                new Employee
                {
                    Name = "John Johnson",
                    Position = Position.ProjectManager,
                    Salary = 15000,
                    Workplace = "SoftServe Ukraine",
                    Email = "john@gmail.com",
                    Address = "Ukraine",
                    ProjectId = 1,
                },
                new Employee
                {
                    Name = "Christopher Baker",
                    Position = Position.ProjectManager,
                    Salary = 15000,
                    Workplace = "SoftServe Ukraine",
                    Email = "christopher@gmail.com",
                    Address = "Ukraine",
                    ProjectId = 2,                    
                },
                new Employee
                {
                    Name = "Andriy Stytsyuk",
                    Position = Position.DeliveryDirector,
                    Salary = 15000,
                    Workplace = "SoftServe Ukraine",
                    Email = "adriy@gmail.com",
                    Address = "Ukraine"
                },
                new Employee
                {
                    Name = "Oleh Denys",
                    Position = Position.CEO,
                    Salary = 20000,
                    Workplace = "SoftServe Ukraine",
                    Email = "oleh@gmail.com",
                    Address = "Ukraine",                    
                }};

            foreach (var item in employee)
            {
                context.Employees.AddOrUpdate(item);
            }
            context.SaveChanges();
        }

        // Seed teams method
        private static void SeedTeams(EmployeeDbContext context)
        {
            var teams = new List<Team>{
              new Team
              {
                  Name = "HR system Back End",
                  ProjectId = 1
              },
              new Team{
                  Name = "HR system Front End",
                  ProjectId = 1
              },
              new Team
              {
                  Name = "NASA system",
                  ProjectId = 2
              }};

            foreach (var item in teams)
            {
                context.Teams.AddOrUpdate(item);
            }
            context.SaveChanges();
        }

        // Seed projects method
        private static void SeedProjects(EmployeeDbContext context)
        {
            var projects = new List<Project>{
                  new Project
                  {
                      ProjectName = "HR management system",
                      Description = "System that helps Hr's to manage employees in company"
                  },
                  new Project
                  {
                      ProjectName = "New NASA operating system",
                      Description = "It's top secret"
                  }};

            foreach (var item in projects)
            {
                context.Projects.AddOrUpdate(item);
            }
            context.SaveChanges();
        }
    }
}