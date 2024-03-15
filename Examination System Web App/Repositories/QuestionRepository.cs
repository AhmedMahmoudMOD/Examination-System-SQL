using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        ExamSysContext _sysContext;

        public QuestionRepository(ExamSysContext sysContext)
        {
            _sysContext = sysContext;
        }

        public List<Question> GetAll()
        {
            return _sysContext.Questions.ToList();
        }

        public Question GetById(int id)
        {
            return _sysContext.Questions.SingleOrDefault(q=>q.q_id==id);
        }

        public void Add(Question question)
        {
            _sysContext.Questions.Add(question);
            _sysContext.SaveChanges();
        }
    }
}
