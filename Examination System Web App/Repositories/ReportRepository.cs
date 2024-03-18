using Examination_System_Web_App.Models;
using Examination_System_Web_App.View_Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Examination_System_Web_App.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ExamSysContext db;

        public ReportRepository(ExamSysContext db)
        {
            this.db = db;
        }

        public IQueryable<TopicsReportVM> GetTopicsReport(int crsId)
        {
            var data = db.Database.SqlQuery<TopicsReportVM>($"sp_GetAllTopisForCourse {crsId}");

            return data;
        }

        public IQueryable<StudentPerDeptReportVM> GetStudentPerDeptReport(int deptNo)
        {
            var data = db.Database.SqlQuery<StudentPerDeptReportVM>($"sp_report_AllStudentIndepartmentByID {deptNo}");

            return data;
        }


    }
}
