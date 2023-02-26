using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand>
{
    private readonly ICoursesRepository _repository;
    private readonly IMediator _mediator;

    public RemoveCourseCommandHandler(
        ICoursesRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.Id));
        await _repository.RemoveCourse(course, cancellationToken);
    }
}
