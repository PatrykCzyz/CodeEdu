using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class AddSubjectToCourseCommand : IRequest
{
    public AddSubjectToCourseCommand(Guid courseId, string subjectName)
    {
        CourseId = courseId;
        SubjectName = subjectName;
    }

    public Guid CourseId { get; set; }
    public string SubjectName { get; set; }
}

