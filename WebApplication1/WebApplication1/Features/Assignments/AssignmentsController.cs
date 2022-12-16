using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Assignments.Models;
using WebApplication1.Features.Assignments.Views;

namespace WebApplication1.Features.Assignments;

[ApiController]
[Route(template: "assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();

    public AssignmentsController() {}

    [HttpPost]

    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel //mapping
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            DeadLine = request.DeadLine
        };
        
        _mockDb.Add(assignment);
        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            DeadLine = assignment.DeadLine
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                DeadLine = assignment.DeadLine
            }).ToList();
    }

    [HttpGet(template: "{id}")]
    public AssignmentResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);
        if (assignment is null)
        {
            return null;
        }

        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            DeadLine = assignment.DeadLine
        };
    }
}

//tema o metoda de cautare dupa id
//o fct de delete si una de update httpdelete si httppatch
