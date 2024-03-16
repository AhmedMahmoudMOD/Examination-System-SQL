using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();

        Question GetById(int id);

        void Add(Question question);

        void Update(Question question);
    }
}
