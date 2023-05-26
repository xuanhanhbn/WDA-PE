using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;
using WDA_PE.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddScoped<IRepository<Exam>, ExamRepository>();
builder.Services.AddScoped<IRepository<Classroom>, ClassroomRepository>();
builder.Services.AddScoped<IRepository<Subject>, SubjectRepository>();
builder.Services.AddScoped<IRepository<Faculty>, FacultyRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
