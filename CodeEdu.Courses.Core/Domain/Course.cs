using System;
using System.Collections.Generic;
using System.Linq;
using CodeEdu.Courses.Core.Exceptions;

namespace CodeEdu.Courses.Core.Domain;

public class Course
{
    public Course(string name)
    {
        Name = name;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void AddSubject(string name)
    {
        var nextNumber = Subjects.Count + 1;
        var subject = new Subject(name, nextNumber);
        Subjects.Add(subject);
    }

    public void RemoveSubject(Guid subjectId)
    {
        var subject = Subjects.Find(s => s.Id == subjectId);

        if (subject is null)
        {
            throw new SubjectNotFoundException();
        }

        Subjects.Remove(subject);
        Subjects
            .Where(s => s.Number > subject.Number)
            .OrderBy(s => s.Number)
            .ToList()
            .ForEach(s => --s.Number);
    }

    public string Name
    {
        get => _name;
        private set
        {
            if (value is null || value.Trim() == string.Empty)
            {
                throw new CourseNameIsEmptyException();
            }

            if (value.Length > 30)
            {
                throw new CourseNameTooLongException();
            }

            _name = value;
        }
    }
    public string? Description { get; private set; }
    public List<Subject> Subjects { get; private set; } = new();

    private string _name;
}

