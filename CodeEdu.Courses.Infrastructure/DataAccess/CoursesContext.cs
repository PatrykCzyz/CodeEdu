using System;
using System.Reflection;
using CodeEdu.Courses.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeEdu.Courses.Infrastructure;

public class CoursesContext : DbContext
{
    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
}
