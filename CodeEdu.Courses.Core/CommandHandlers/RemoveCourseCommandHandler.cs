using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.CommandHandlers;

public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand>
{
    private readonly ICourseRepository _repository;

    public RemoveCourseCommandHandler(ICourseRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        return _repository.RemoveCourse(request.Id, cancellationToken);
    }
}
