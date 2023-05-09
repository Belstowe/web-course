using Microsoft.EntityFrameworkCore;

namespace MyCourse.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariableAnswer>();
            modelBuilder.Entity<ChoicesAnswer>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Quiz> Quizzes { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;
    }
}
