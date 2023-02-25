using System;
using CodeEdu.Courses.Core.Domain;
using MediatR;

namespace CodeEdu.Courses.Core.Queries;

public class GetCourseByIdQuery : IRequest<Course>
{
    public GetCourseByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
