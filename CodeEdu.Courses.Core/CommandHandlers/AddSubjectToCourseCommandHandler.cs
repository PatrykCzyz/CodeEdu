using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class AddSubjectToCourseCommandHandler : IRequestHandler<AddSubjectToCourseCommand>
{
    private readonly ICoursesRepository _repository;
    private readonly IMediator _mediator;

    public AddSubjectToCourseCommandHandler(
        ICoursesRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(AddSubjectToCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.CourseId), cancellationToken);

        var subject = course.AddSubject(request.SubjectName);

        await _repository.AddSubject(subject, cancellationToken);
    }
}
