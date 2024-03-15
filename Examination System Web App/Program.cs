using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ExamSysContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("Data Source=tcp:pdsqlproject.database.windows.net,1433;Initial Catalog=ExamSys;User ID=sqladmin@pdsqlproject;Password=Adminpass_123;Connect Timeout=1200");
            });

            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
