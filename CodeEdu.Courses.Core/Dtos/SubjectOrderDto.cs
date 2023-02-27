using System;
namespace CodeEdu.Courses.Core.Dtos;

public class SubjectOrderDto
{
	public SubjectOrderDto(Guid subjectId, int number)
	{
		SubjectId = subjectId;
		Number = number;
	}

	public Guid SubjectId { get; }
	public int Number { get; }
}

