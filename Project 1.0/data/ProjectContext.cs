using Microsoft.EntityFrameworkCore;

namespace Project_1._0.data
{
    public class ProjectContext : DbContext
    {
        public DbSet<Update> Updates { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost:3306;database=project1_db;user=root;password=M@98rk73u$",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}
