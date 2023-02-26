using System;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Exceptions;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Courses.Core.Repositories;
using MediatR;

namespace CodeEdu.Courses.Core.QueryHandlers;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
{
    private readonly ICoursesRepository _repository;

    public GetCourseByIdQueryHandler(ICoursesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetCourse(request.Id, cancellationToken);

        if (course is null)
        {
            throw new CourseNotFoundException();
        }

        return course;
    }
}

