using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-9NM7MA7\SQLEXPRESS;Database=SoftUni1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnType("char(10)")
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Birthday)
                    .IsRequired(false);
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(true);

                entity.Property(e => e.Description)
                    .IsUnicode(true)
                    .IsRequired(false);
            });
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(e => e.Url)
                    .IsRequired(false)
                    .IsUnicode(false);
                    
                entity.HasOne(e => e.Course)
                    .WithMany(e => e.Resources)
                    .HasForeignKey(e => e.CourseId);
            });
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionTime)
                    .IsRequired(true)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Student)
                    .WithMany(e => e.HomeworkSubmissions);

                entity.HasOne(e => e.Course)
                    .WithMany(e => e.HomeworkSubmissions);
            });
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new {e.CourseId, e.StudentId});

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentsEnrolled)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.StudentId);
            });
        }
    }
}
