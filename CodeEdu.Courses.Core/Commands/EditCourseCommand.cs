using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class EditCourseCommand : IRequest
{
    public EditCourseCommand(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
}

