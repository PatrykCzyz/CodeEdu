using System;
using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeEdu.Courses.Infrastructure.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly CoursesContext _context;

    public CoursesRepository(CoursesContext context)
    {
        _context = context;
    }

    public async Task AddCourse(Course course, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(course, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddSubject(Subject subject, CancellationToken cancellationToken = default)
    {
        await _context.Subjects.AddAsync(subject, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<Course?> GetCourse(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Courses.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Course>> GetCourses(CancellationToken cancellationToken = default)
    {
        return await _context.Courses.ToListAsync(cancellationToken);
    }

    public async Task RemoveCourse(Course course, CancellationToken cancellationToken = default)
    {
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveSubject(Subject subject, CancellationToken cancellationToken = default)
    {
        _context.Remove(subject);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}

