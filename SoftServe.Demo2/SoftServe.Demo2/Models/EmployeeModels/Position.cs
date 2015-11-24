using System.ComponentModel.DataAnnotations;

namespace SoftServe.Demo2.Models.EmployeesModel
{
    public enum Position
    {
        Trainee,
        Junior,
        Intermediate,
        Senior,
        [Display(Name = "Team Leader")]
        TeamLeader,
        [Display(Name = "Project Manager")]
        ProjectManager,
        [Display(Name = "Delivery Director")]
        DeliveryDirector,
        CEO
    }
}