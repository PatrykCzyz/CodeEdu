using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodeEdu.Courses.Core.Domain;

namespace CodeEdu.Courses.Core.Repositories;

public interface ICoursesRepository
{
    public Task AddCourse(Course course, CancellationToken cancellationToken = default);
    public Task AddSubject(Subject subject, CancellationToken cancellationToken = default);
    public Task<Course?> GetCourse(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Course>> GetCourses(CancellationToken cancellationToken);
    Task RemoveCourse(Course course, CancellationToken cancellationToken = default);
    Task RemoveSubject(Subject subject, CancellationToken cancellationToken = default);
    Task SaveChanges(CancellationToken cancellationToken = default);
}
