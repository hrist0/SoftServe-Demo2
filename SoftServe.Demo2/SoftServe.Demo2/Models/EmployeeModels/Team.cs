using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftServe.Demo2.Models.EmployeesModel
{
    public class Team
    {
        private ICollection<Employee> employees;

        public Team()
        {
            this.employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Team name")]
        public string Name { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        [DisplayName("Team name")]
        public virtual Project Project { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}