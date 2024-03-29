using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examination_System_Web_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //commit 
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2UFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5Qd01jW39ccnNXRmZV");

            builder.Services.AddDbContext<ExamSysContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("Data Source=tcp:pdsqlproject.database.windows.net,1433;Initial Catalog=ExamSys;User ID=sqladmin@pdsqlproject;Password=Adminpass_123;Connect Timeout=1200");
            });

            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            builder.Services.AddScoped<IChoiceRepository, ChoiceRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
