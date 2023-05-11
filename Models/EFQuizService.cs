namespace MyCourse.Models
{
    public class EFQuizService : IQuizService
    {
        public int? AddQuestion(int quizID, Question question)
        {
            throw new NotImplementedException();
        }

        public int? CreateQuiz(string name, string author)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestion(int questionID)
        {
            throw new NotImplementedException();
        }

        public Question? GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestions(int id)
        {
            throw new NotImplementedException();
        }

        public Quiz? GetQuiz(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quiz> GetQuizzes()
        {
            throw new NotImplementedException();
        }
    }
}