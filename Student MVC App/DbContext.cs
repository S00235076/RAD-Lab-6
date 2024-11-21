using Microsoft.EntityFrameworkCore;
using Student_Class_Library;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Student_MVC_App
{
    public class CollegeContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source=C:\\Users\\S00235076\\source\\repos\\Lab 6\\Student Console App\\students.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourse"));
        }
    }
}
