using System.ComponentModel.DataAnnotations;

namespace SoftServe.Demo2.Models.EmployeesModel
{
    public enum Position
    {
        Trainee,
        Junior,
        Intermediate,
        Senior,
        [DisplayAttribute(Name = "Team Leader")]
        TeamLeader,
        [DisplayAttribute(Name = "Project Manager")]
        ProjectManager,
        [Display(Name = "Delivery Director")]
        DeliveryDirector,
        CEO
    }
}