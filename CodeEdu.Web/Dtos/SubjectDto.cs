using System;
using CodeEdu.Courses.Core.Domain;

namespace CodeEdu.Web.Dtos;

public class SubjectDto
{
    public SubjectDto(Guid id, string name, int number)
    {
        Id = id;
        Name = name;
        Number = number;
    }

    public static SubjectDto FromDomain(Subject subject)
    {
        return new SubjectDto(subject.Id, subject.Name, subject.Number);
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public int Number { get; private set; }
}
