using CodeEdu.Courses.Core.Domain;
using CodeEdu.Courses.Core.Exceptions;
using FluentAssertions;

namespace CodeEdu.Courses.Tests.Tests;

public class CourseTests
{
    [Fact]
    public void ShouldCreateCourse()
    {
        // Arrange
        var courseName = "Test";

        // Act
        var course = new Course(courseName);

        // Assert
        course.Name.Should().Be(courseName);
        course.Description.Should().Be(null);
        course.Subjects.Should().HaveCount(0);
    }

    [Theory()]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ShouldThrowExceptionWithEmptyNameOrNull(string courseName)
    {
        // Act
        var act = () => new Course(courseName);

        // Assert
        act.Should().Throw<CourseNameIsEmptyException>();
    }

    [Fact]
    public void ShouldThrowExceptionWithNameMoreThan30Char()
    {
        // Arrange
        var courseName = new string('*', 31);

        // Act
        var act = () => new Course(courseName);

        // Assert
        act.Should().Throw<CourseNameTooLongException>();
    }

    [Fact]
    public void ShouldSetDescription()
    {
        // Arrange
        var courseName = "Name";
        var course = new Course(courseName);
        var courseDescription = "This is a description of the course";

        // Act
        course.Description = courseDescription;

        // Assert
        course.Description.Should().Be(courseDescription);
    }

    [Fact]
    public void ShouldAddSubjectWithNumber()
    {
        // Arrange
        var courseName = "Name";
        var course = new Course(courseName);
        var subjectName = "Subject name";

        // Act
        course.AddSubject(subjectName);

        // Assert
        course.Subjects.Should().ContainSingle();
        course.Subjects.First().Name.Should().Be(subjectName);
        course.Subjects.First().Number.Should().Be(1);
    }

    [Fact]
    public void ShouldAddMultipleSubjectsWithProperNumbers()
    {
        // Arrange
        var courseName = "Name";
        var course = new Course(courseName);
        var subjectName = "Subject name";

        // Act
        course.AddSubject(subjectName);
        course.AddSubject(subjectName);
        course.AddSubject(subjectName);

        // Assert
        course.Subjects.Should().HaveCount(3);

        for (int i = 0; i < course.Subjects.Count; i++)
        {
            course.Subjects[i].Number.Should().Be(i + 1);
        }
    }

    [Fact]
    public void ShouldRemoveSubjectAndSetNumbers()
    {
        // Arrange
        var courseName = "Name";
        var course = new Course(courseName);
        var subjectName = "Subject name";
        course.AddSubject(subjectName);
        course.AddSubject(subjectName);
        course.AddSubject(subjectName);

        // Act
        course.RemoveSubject(course.Subjects[1].Id);

        // Assert
        course.Subjects.Should().HaveCount(2);

        for (int i = 0; i < course.Subjects.Count; i++)
        {
            course.Subjects[i].Number.Should().Be(i + 1);
        }
    }

    [Fact]
    public void ShouldThrowIfSubjectNotFound()
    {
        // Arrange
        var courseName = "Name";
        var course = new Course(courseName);
        var subjectName = "Subject name";
        course.AddSubject(subjectName);

        // Act
        var act = () => course.RemoveSubject(Guid.NewGuid());

        // Assert
        act.Should().Throw<SubjectNotFoundException>();
    }

    [Theory()]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ShouldThrowExceptionWithEmptyOrNullSubjectName(string subjectName)
    {
        // Arrange
        var course = new Course("Name");
        // Act
        var act = () => course.AddSubject(subjectName);

        // Assert
        act.Should().Throw<SubjectNameIsEmptyException>();
    }

    [Fact]
    public void ShouldThrowExceptionWithNameMoreThan40Char()
    {
        // Arrange
        var subjectName = new string('*', 41);

        // Act
        var act = () => new Course(subjectName);

        // Assert
        act.Should().Throw<CourseNameTooLongException>();
    }
}
