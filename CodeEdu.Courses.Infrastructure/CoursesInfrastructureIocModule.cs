using System;
using Autofac;
using CodeEdu.Courses.Core.Repositories;
using CodeEdu.Courses.Infrastructure.Repositories;
using Module = Autofac.Module;

namespace CodeEdu.Courses.Infrastructure;

public class CoursesInfrastructureIocModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CoursesRepository>().As<ICoursesRepository>().InstancePerLifetimeScope();
    }
}
