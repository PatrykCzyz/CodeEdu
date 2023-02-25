using System;
using MediatR;

namespace CodeEdu.Courses.Core.Commands;

public class RemoveCourseCommand : IRequest
{
	public RemoveCourseCommand(Guid id)
	{
		Id = id;
	}

	public Guid Id { get; private set; }
}

