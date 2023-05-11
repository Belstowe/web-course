namespace MyCourse.Models
{
    public interface IQuizService
    {
        int? CreateQuiz(string name, string author);
        Quiz? GetQuiz(int id);
        IEnumerable<Quiz> GetQuizzes();
        int? AddQuestion(int quizID, Question question);
        Question? GetQuestion(int id);
        IEnumerable<Question> GetQuestions(int id);
        bool DeleteQuestion(int questionID);
    }
}
