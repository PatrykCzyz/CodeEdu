using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class EditSubjectCommand : IRequest
{
	public EditSubjectCommand(Guid courseId, Guid subjectId, string subjectName)
	{
		CourseId = courseId;
		SubjectId = subjectId;
		SubjectName = subjectName;
	}

	public Guid CourseId { get; private set; }
	public Guid SubjectId { get; private set; }
	public string SubjectName { get; private set; }
}

