using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class CreateCourseCommand : IRequest<Guid>
{
    public CreateCourseCommand(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
}

