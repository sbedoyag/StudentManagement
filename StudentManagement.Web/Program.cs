using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Infrastructure.Data;
using StudentManagement.Web.Mapping;
using StudentManagement.Web.Services;
using StudentManagement.Web.Services.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
}
builder.Services.AddDbContext<StudentManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

// DI Repositories and Services
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddAutoMapper(mapper =>
{
    mapper.CreateMap<Student, StudentViewModel>();
    mapper.CreateMap<Subject, SubjectViewModel>();
    
    mapper.CreateMap<SubjectViewModel, Subject>();
    mapper.CreateMap<StudentViewModel, Student>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
