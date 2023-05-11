namespace MyCourse.Models
{
    public interface IQuizService
    {
        int? CreateQuiz(string name, string author);
        Quiz? GetQuiz(int id);
        IEnumerable<Quiz> GetQuizzes();
        bool DeleteQuiz(int id);
        int? AddVariableQuestion(Quiz quiz, string text, string hint = "");
        int? AddChoicesQuestion(Quiz quiz, string text, IEnumerable<string> choices);
        Question? GetQuestion(int id);
        IEnumerable<Question> GetQuestions(int quizID);
        bool DeleteQuestion(int id);
    }
}
