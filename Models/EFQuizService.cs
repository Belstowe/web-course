namespace MyCourse.Models
{
    public sealed class EFQuizService : IQuizService
    {
        private static int quizCounter = 0;
        private static int questionCounter = 0;
        private readonly QuizContext ctx;

        public EFQuizService(QuizContext ctx)
        {
            this.ctx = ctx;
        }

        public int? AddVariableQuestion(Quiz quiz, string text, string hint = "")
        {
            var entry = ctx.Questions.Add(new VariableQuestion{
                QuestionID = ++questionCounter,
                Quiz = quiz,
                QuizRefID = quiz.QuizID,
                Text = text,
                Hint = hint
            });
            if (entry is null) {
                --questionCounter;
                return null;
            }
            return questionCounter;
        }
        
        public int? AddChoicesQuestion(Quiz quiz, string text, IEnumerable<string> choices)
        {
            var entry = ctx.Questions.Add(new ChoicesQuestion{
                QuestionID = ++questionCounter,
                Quiz = quiz,
                QuizRefID = quiz.QuizID,
                Text = text,
                Choices = choices
            });
            if (entry is null) {
                --questionCounter;
                return null;
            }
            return questionCounter;
        }

        public int? CreateQuiz(string name, string author)
        {
            var entry = ctx.Quizzes.Add(new Quiz{
                QuizID = ++quizCounter,
                Name = name,
                Author = author
            });
            if (entry is null) {
                --quizCounter;
                return null;
            }
            return quizCounter;
        }

        public bool DeleteQuestion(int questionID)
        {
            var question = ctx.Questions.First(question => question.QuestionID == questionID);
            if (question is null) {
                return false;
            }
            ctx.Remove(question);
            return true;
        }

        public Question? GetQuestion(int id)
        {
            return ctx.Questions.Find(id);
        }

        public IEnumerable<Question> GetQuestions(int quizID)
        {
            return ctx.Questions.Where(question => question.QuizRefID == quizID).AsEnumerable();
        }

        public Quiz? GetQuiz(int id)
        {
            return ctx.Quizzes.Find(id);
        }

        public IEnumerable<Quiz> GetQuizzes()
        {
            return ctx.Quizzes.AsEnumerable();
        }
    }
}
