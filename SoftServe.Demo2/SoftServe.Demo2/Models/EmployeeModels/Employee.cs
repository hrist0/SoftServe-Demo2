using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftServe.Demo2.Models.EmployeesModel
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [DisplayName("Employee name")]
        [StringLength(35, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public Position Position { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Work place is required")]
        public string Workplace { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email address is not valid")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        public string Phone { get; set; }

        [DisplayName("Home address")]
        public string HomeAdress { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}