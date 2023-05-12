using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyCourse.Models
{
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; } = default!;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Author { get; set; } = default!;
        public string Name { get; set; } = default!;

        public List<Question> Questions { get; } = new();
    }

    public abstract class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string Text { get; set; } = default!;

        [ForeignKey("Quiz")]
        public int QuizRefID { get; set; }
        public Quiz Quiz { get; set; } = default!;
    }

    public class VariableQuestion : Question
    {
        public string Hint { get; set; } = default!;
    }

    public class ChoicesQuestion : Question
    {
        public IEnumerable<string> Choices { get; set; } = default!;
        public bool AllowMultipleChoices { get; set; } = false;
    }

    [Index(nameof(AnswerSpree), IsUnique = false)]
    public abstract class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public Guid AnswerSpree { get; set; }

        [ForeignKey("Question")]
        public int QuestionRefID { get; set; }
        public Question Question { get; set; } = default!;
    }

    public class VariableAnswer : Answer
    {
        public string Input { get; set; } = default!;
    }

    public class ChoicesAnswer : Answer
    {
        public IEnumerable<int> Choices { get; set; } = default!;
    }
}
