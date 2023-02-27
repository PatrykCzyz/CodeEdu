using System;
using System.Collections.Generic;
using CodeEdu.Courses.Core.Dtos;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class ChangeSubjectsOrderCommand : IRequest
{
	public ChangeSubjectsOrderCommand(Guid courseId, IReadOnlyList<SubjectOrderDto> newOrder)
	{
		CourseId = courseId;
		NewOrder = newOrder;
	}

	public Guid CourseId { get; }
	public IReadOnlyList<SubjectOrderDto> NewOrder { get; }
}

