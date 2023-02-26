using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.QueryHandlers;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IReadOnlyList<Course>>
{
    private readonly ICoursesRepository _respository;

    public GetCoursesQueryHandler(ICoursesRepository respository)
    {
        _respository = respository;
    }

    public Task<IReadOnlyList<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return _respository.GetCourses(cancellationToken);
    }
}

