using System;
using System.Collections.Generic;
using CodeEdu.Courses.Core.Domain;
using MediatR;

namespace CodeEdu.Courses.Core.Queries;

public class GetCoursesQuery : IRequest<IReadOnlyList<Course>>
{
}
