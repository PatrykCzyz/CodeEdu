using System;
using System.Xml.Linq;
using CodeEdu.Courses.Core.Exceptions;

namespace CodeEdu.Courses.Core.Domain;

public class Subject
{
    public Subject(string name, int number)
    {
        Id = Guid.NewGuid();
        Name = name;
        Number = number;
    }

    public Guid Id { get; private set; }
    public string Name
    {
        get => _name;
        private set
        {
            if(value is null || value.Trim() == string.Empty)
            {
                throw new SubjectNameIsEmptyException();
            }

            if (value.Length > 40)
            {
                throw new SubjectNameIsTooLong();
            }

            _name = value;
        }
    }
    public int Number { get; set; }

    private string _name;
}

