using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly ExamSysContext db;

        public ChoiceRepository(ExamSysContext db)
        {
            this.db = db;
        }

        public void Add (Choice choice)
        {
            db.Add(choice);
            db.SaveChanges();
        }
    }
}
