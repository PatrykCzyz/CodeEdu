using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Exceptions;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class RemoveSubjectCommandHandler : IRequestHandler<RemoveSubjectCommand>
{
    private readonly ICourseRepository _repository;
    private readonly IMediator _mediator;

    public RemoveSubjectCommandHandler(
        ICourseRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(RemoveSubjectCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.CourseId), cancellationToken);

        if (course is null)
        {
            throw new CourseNotFoundException();
        }

        var subject = course.RemoveSubject(request.SubjectId);

        await _repository.SaveChanges(cancellationToken);
    }
}

