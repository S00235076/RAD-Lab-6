using Microsoft.EntityFrameworkCore;
using Student_Class_Library;

namespace Student_MVC_App.Data
{
    public class CollegeContext : DbContext
    {
        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Math 101" },
                new Course { Id = 2, Name = "History 101" }
            );


            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, Name = "John Doe", EmailAddress = "john.doe@example.com" },
               new Student { Id = 2, Name = "Jane Smith", EmailAddress = "jane.smith@example.com" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
