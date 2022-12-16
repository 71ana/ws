using WebApplication1.Base;

namespace WebApplication1.Features.Assignments.Models;

public class AssignmentModel : Model
{
    public string Subject { get; set; }

    public string Description { get; set; }

    public DateTime DeadLine { get; set; }
}