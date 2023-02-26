using CodeEdu.Courses.Core.Commands;
using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Queries;
using CodeEdu.Web.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeEdu.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddCourse(AddCourseDto dto, CancellationToken cancellationToken)
    {
        var courseId = await _mediator.Send(new CreateCourseCommand(dto.Name, dto.Description), cancellationToken);

        return Ok(new { courseId });
    }

    [HttpPatch("[action]/{courseId}")]
    public async Task<IActionResult> EditCourse(
        Guid courseId,
        EditCourseDto dto,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new EditCourseCommand(courseId, dto.Name, dto.Description), cancellationToken);

        return Ok();
    }

    [HttpPost("[action]/{courseId}")]
    public async Task<IActionResult> AddSubjectToCourse(
        Guid courseId,
        AddSubjectDto dto,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new AddSubjectToCourseCommand(courseId, dto.Name), cancellationToken);

        return Ok();
    }

    [HttpGet("[action]/{courseId}")]
    public async Task<ActionResult<CourseDto>> GetCourse(
        Guid courseId,
        CancellationToken cancellationToken)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(courseId), cancellationToken);

        return Ok(CourseDto.FromDomain(course));
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IReadOnlyList<CourseDto>>> GetCourses(CancellationToken cancellationToken)
    {
        var courses = await _mediator.Send(new GetCoursesQuery(), cancellationToken);

        return Ok(courses.Select(CourseDto.FromDomain).ToList());
    }

    [HttpPatch("[action]/{courseId}/{subjectId}")]
    public async Task<IActionResult> EditSubject(
        Guid courseId,
        Guid subjectId,
        EditSubjectDto dto,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new EditSubjectCommand(courseId, subjectId, dto.Name), cancellationToken);

        return Ok();
    }

    [HttpDelete("[action]/{courseId}/{subjectId}")]
    public async Task<IActionResult> RemoveSubject(
        Guid courseId,
        Guid subjectId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new RemoveSubjectCommand(courseId, subjectId), cancellationToken);

        return Ok();
    }

    [HttpDelete("[action]/{courseId}")]
    public async Task<IActionResult> RemoveCourse(
        Guid courseId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new RemoveCourseCommand(courseId), cancellationToken);

        return Ok();
    }
}

