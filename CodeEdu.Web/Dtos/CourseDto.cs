using System;
using CodeEdu.Courses.Core.Domain;

namespace CodeEdu.Web.Dtos;

public class CourseDto
{
    public CourseDto(Guid id, string name, string? description, IReadOnlyList<SubjectDto> subjects)
    {
        Id = id;
        Name = name;
        Description = description;
        Subjects = subjects;
    }

    public static CourseDto FromDomain(Course course)
    {
        return new CourseDto(
            course.Id,
            course.Name,
            course.Description,
            course.Subjects.Select(SubjectDto.FromDomain).ToList());
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyList<SubjectDto> Subjects { get; private set; }
}
