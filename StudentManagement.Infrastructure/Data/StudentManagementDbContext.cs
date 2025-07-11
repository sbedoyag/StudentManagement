using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entities;

namespace StudentManagement.Infrastructure.Data
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.HasKey(s => new { s.StudentDocument, s.SubjectCode });

                entity.HasOne(s => s.Student)
                .WithMany(s => s.Subjects)
                .HasForeignKey(s => s.StudentDocument)
                .HasPrincipalKey(s => s.Document)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(s => s.SubjectCode)
                .HasPrincipalKey(s => s.Code)
                .OnDelete(DeleteBehavior.Cascade);
            });


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}
