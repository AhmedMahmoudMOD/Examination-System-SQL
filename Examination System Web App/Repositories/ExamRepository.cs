using Examination_System_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamSysContext db;

        public ExamRepository(ExamSysContext db) {
            this.db = db;
        }

        public async Task<int> ExamGeneration(int crsId , int deptNo , string name , int mcqNo , int tfNo , int duration , DateTime date)
        {
           var res =  await db.Database.ExecuteSqlAsync($"EXEC sp_GenerateExam {crsId}, {deptNo}, {mcqNo}, {tfNo}, {duration}, {date}, {name}");

            return res;
        }
    }
}
