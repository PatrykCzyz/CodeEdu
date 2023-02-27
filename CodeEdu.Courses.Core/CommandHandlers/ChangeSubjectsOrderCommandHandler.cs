using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class ChangeSubjectsOrderCommandHandler : IRequestHandler<ChangeSubjectsOrderCommand>
{
    private readonly IMediator _mediator;
    private readonly ICoursesRepository _repository;

    public ChangeSubjectsOrderCommandHandler(
        IMediator mediator,
        ICoursesRepository repository)
	{
        _mediator = mediator;
        _repository = repository;
    }

    public async Task Handle(ChangeSubjectsOrderCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.CourseId), cancellationToken);

        course.ChangeSubjectsOrder(request.NewOrder);

        await _repository.SaveChanges(cancellationToken);
    }
}

