using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftServe.Demo2.Models.EmployeesModel
{
    public class Project
    {
        private ICollection<Team> teams;
        private ICollection<Employee> employees;

        public Project()
        {
            this.teams = new HashSet<Team>();
            this.employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Project name")]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}