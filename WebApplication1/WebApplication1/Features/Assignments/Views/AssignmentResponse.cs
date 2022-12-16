using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Features.Assignments.Views;

public class AssignmentResponse
{
    [Required]public string Id { get; set; }

    [Required]public string Subject { get; set; }

    [Required]public string Description { get; set; }

    [Required]public DateTime DeadLine { get; set; }
}