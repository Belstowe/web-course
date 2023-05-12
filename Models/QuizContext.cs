using Microsoft.EntityFrameworkCore;

namespace MyCourse.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariableQuestion>();
            modelBuilder.Entity<ChoicesQuestion>()
                        .Property(e => e.Choices)
                        .HasConversion(
                            v => string.Join(";;", v),
                            v => v.Split(";;", StringSplitOptions.RemoveEmptyEntries).ToList()
                        );
            modelBuilder.Entity<VariableAnswer>();
            modelBuilder.Entity<ChoicesAnswer>()
                        .Property(e => e.Choices)
                        .HasConversion(
                            v => string.Join(",", v),
                            v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(v => Int32.Parse(v)).ToList()
                        );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Quiz> Quizzes { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;
    }
}
