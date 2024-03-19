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

        public IQueryable<InstCoursesReport> GetCoursesReport(int InsId)
        {
            var date = db.Database.SqlQuery<InstCoursesReport>($"sp_GetNumberOfStudentPerCourseForInstructor {InsId}");

            return date;
        }

        public IQueryable<StudentGradesReportVM> GetStdGrades (int stdId)
        {
            var date = db.Database.SqlQuery<StudentGradesReportVM>($"sp_GetAllStudentGrades {stdId}");

            return date;

        }

        public IQueryable<AnsweReportsVM> GetAsnwer (int std_id , int exam_id)
        {
            var model = db.Database.SqlQuery<AnsweReportsVM>($"sp_GetStdAnswerPerEaxm {std_id} , {exam_id}");
            return model;
        }


    }
}
