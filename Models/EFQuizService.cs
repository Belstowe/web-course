namespace MyCourse.Models
{
    public sealed class EFQuizService : IQuizService
    {
        private static int quizCounter;
        private static int questionCounter;
        private static int answerCounter;
        private readonly QuizContext _context;

        public EFQuizService(QuizContext ctx)
        {
            this._context = ctx;
            quizCounter = ctx.Quizzes.Select(q => q.QuizID).AsEnumerable().DefaultIfEmpty(0).Max();
            questionCounter = ctx.Questions.Select(q => q.QuestionID).AsEnumerable().DefaultIfEmpty(0).Max();
            answerCounter = ctx.Answers.Select(a => a.AnswerID).AsEnumerable().DefaultIfEmpty(0).Max();
        }

        public int? AddVariableQuestion(Quiz quiz, string text, string hint = "")
        {
            var entry = _context.Questions.Add(new VariableQuestion{
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
        
        public int? AddChoicesQuestion(Quiz quiz, string text, IEnumerable<string> choices, bool allowMultipleChoices = false)
        {
            var entry = _context.Questions.Add(new ChoicesQuestion{
                QuestionID = ++questionCounter,
                Quiz = quiz,
                QuizRefID = quiz.QuizID,
                Text = text,
                Choices = choices,
                AllowMultipleChoices = allowMultipleChoices
            });
            if (entry is null) {
                --questionCounter;
                return null;
            }
            return questionCounter;
        }

        public int? CreateQuiz(string name, string author)
        {
            var entry = _context.Quizzes.Add(new Quiz{
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

        public bool DeleteQuiz(int id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz is null) {
                return false;
            }
            _context.Quizzes.Remove(quiz);
            var questions = _context.Questions.Where(question => question.QuizRefID == id);
            _context.Questions.RemoveRange(questions);
            return true;
        }

        public bool DeleteQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question is null) {
                return false;
            }
            _context.Questions.Remove(question);
            return true;
        }

        public Question? GetQuestion(int id)
        {
            return _context.Questions.Find(id);
        }

        public IEnumerable<Question> GetQuestions(int quizID)
        {
            return _context.Questions.Where(question => question.QuizRefID == quizID).AsEnumerable();
        }

        public Quiz? GetQuiz(int id)
        {
            return _context.Quizzes.Find(id);
        }

        public IEnumerable<Quiz> GetQuizzes()
        {
            return _context.Quizzes.AsEnumerable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        int? IQuizService.AddVariableAnswer(Guid answerSpree, Question question, string text)
        {
            var entry = _context.Answers.Add(new VariableAnswer{
                AnswerID = ++answerCounter,
                AnswerSpree = answerSpree,
                QuestionRefID = question.QuestionID,
                Question = question,
                Input = text
            });
            if (entry is null) {
                --answerCounter;
                return null;
            }
            return answerCounter;
        }

        int? IQuizService.AddChoicesAnswer(Guid answerSpree, Question question, IEnumerable<bool> checkedAnswers)
        {
            var answerIndexes = checkedAnswers.Select((c, i) => new { Item = c, Index = i } )
                                              .Where(item => item.Item == true)
                                              .Select(item => item.Index)
                                              .AsEnumerable();
            var entry = _context.Answers.Add(new ChoicesAnswer{
                AnswerID = ++answerCounter,
                AnswerSpree = answerSpree,
                QuestionRefID = question.QuestionID,
                Question = question,
                Choices = answerIndexes
            });
            if (entry is null) {
                --answerCounter;
                return null;
            }
            return answerCounter;
        }

        Answer? IQuizService.GetAnswer(int id)
        {
            return _context.Answers.Find(id);
        }

        IEnumerable<Answer> IQuizService.GetAnswers(Guid answerSpree)
        {
            return _context.Answers.Where(answer => answer.AnswerSpree == answerSpree).AsEnumerable();
        }
    }
}
