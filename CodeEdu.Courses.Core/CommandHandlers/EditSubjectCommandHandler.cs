using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class EditSubjectCommandHandler : IRequestHandler<EditSubjectCommand>
{
    private readonly ICourseRepository _repository;
    private readonly IMediator _mediator;

    public EditSubjectCommandHandler(
        ICourseRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task Handle(EditSubjectCommand request, CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(request.CourseId), cancellationToken);

        course.ChangeSubjectName(request.SubjectId, request.SubjectName);

        await _repository.SaveChanges(cancellationToken);
    }
}

