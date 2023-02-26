using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Exceptions;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand>
{
    private readonly ICoursesRepository _repository;
    private readonly IMediator _mediator;

    public EditCourseCommandHandler(
        ICoursesRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(EditCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.Id), cancellationToken);

        if (course == null)
        {
            throw new CourseNotFoundException();
        }

        course.Name = request.Name;
        course.Description = request.Description;

        await _repository.SaveChanges(cancellationToken);
    }
}
