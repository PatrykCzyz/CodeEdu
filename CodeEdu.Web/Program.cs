using System;
using Autofac;
using CodeEdu.Courses.Core;
using CodeEdu.Courses.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using CodeEdu.Web.Options;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new CoursesCoreIocModule());
    builder.RegisterModule(new CoursesInfrastructureIocModule());
});

builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CoursesContext>(options =>
{
    var mySqlOptions = builder.Configuration.GetSection("MySql").Get<MySqlOptions>();

    var serverVersion = new MySqlServerVersion(new Version(
        mySqlOptions.Version.Major,
        mySqlOptions.Version.Minor,
        mySqlOptions.Version.Patch));

    options.UseMySql(builder.Configuration.GetConnectionString("CoursesContext"), serverVersion);
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

