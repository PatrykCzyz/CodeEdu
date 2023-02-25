using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
{
    private readonly ICourseRepository _repository;

    public CreateCourseCommandHandler(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(request.Name);

        if (request.Description != null)
        {
            course.Description = request.Description;
        }

        await _repository.AddCourse(course, cancellationToken);
    }
}

