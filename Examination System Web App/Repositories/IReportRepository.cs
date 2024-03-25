using Examination_System_Web_App.View_Models;
using System.Data;

namespace Examination_System_Web_App.Repositories
{
    public interface IReportRepository
    {
        IQueryable<TopicsReportVM> GetTopicsReport(int crsId);

        IQueryable<StudentPerDeptReportVM> GetStudentPerDeptReport(int deptNo);

        IQueryable<InstCoursesReport> GetCoursesReport(int InsId);

        IQueryable<StudentGradesReportVM> GetStdGrades(int stdId);
        IQueryable<AnsweReportsVM> GetAsnwer(int std_id, int exam_id);

        DataTable GenExamQuestionsReport(int examId);

    }
}
