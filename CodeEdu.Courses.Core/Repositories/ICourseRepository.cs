using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Domain;

namespace CodeEdu.Courses.Core.Repositories;

public interface ICourseRepository
{
    public Task AddCourse(Course course, CancellationToken? cancellationToken = default);
    public Task<Course> GetCourse(Guid id, CancellationToken? cancellationToken = default);
    Task<IReadOnlyList<Course>> GetCourses(CancellationToken cancellationToken);
    Task RemoveCourse(Guid id, CancellationToken? cancellationToken = default);
    Task SaveChanges(CancellationToken? cancellationToken = default);
}
