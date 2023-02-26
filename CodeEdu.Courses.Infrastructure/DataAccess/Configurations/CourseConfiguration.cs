using System;
using CodeEdu.Courses.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeEdu.Courses.Infrastructure.DataAccess.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .HasMany(c => c.Subjects)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

