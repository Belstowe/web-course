using System.ComponentModel.DataAnnotations;

namespace MyCourse.Models
{
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; } = default!;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Author { get; set; } = default!;

        public List<Question> Questions { get; } = new();
    }

    public abstract class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string Text { get; set; } = default!;
        public Quiz Quiz { get; set; } = default!;
    }

    public class VariableQuestion : Question
    {
        public string Hint { get; set; } = default!;
    }

    public class ChoicesQuestion : Question
    {
        public List<string> Choices { get; set; } = new();
    }
}
