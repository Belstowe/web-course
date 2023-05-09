using System.ComponentModel.DataAnnotations;

namespace MyCourse.Models
{
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; } = default!;
        public string Author { get; set; } = default!;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }

    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string Text { get; set; } = default!;
        public Quiz Quiz { get; set; } = default!;

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }

    public abstract class Answer
    {
        public int AnswerID { get; set; }
        public Question Question { get; set; } = default!;
    }

    public class VariableAnswer : Answer
    {
        public string Hint { get; set; } = default!;
    }

    public class ChoicesAnswer : Answer
    {
        public ICollection<string> Choices { get; set; } = new List<string>();
    }
}
