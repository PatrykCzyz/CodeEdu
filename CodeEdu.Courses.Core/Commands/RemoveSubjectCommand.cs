using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class RemoveSubjectCommand : IRequest
{
    public RemoveSubjectCommand(Guid courseId, Guid subjectId)
    {
        CourseId = courseId;
        SubjectId = subjectId;
    }

    public Guid CourseId { get; private set; }
    public Guid SubjectId { get; private set; }
}

