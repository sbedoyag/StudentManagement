using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;
using System.Reflection.Metadata;

namespace StudentManagement.Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext _context;

        public StudentRepository(StudentManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByDocumentAsync(string document)
        {
            return await _context.Students
                .AsNoTracking()
                .Include(s => s.Subjects)
                .FirstOrDefaultAsync(s => s.Document == document);
        }

        public async Task CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Attach(student).State = EntityState.Modified;
            await AddSubjectAsync(student.Document, student.Subjects);
            await _context.SaveChangesAsync();
        }

        public async Task AddSubjectAsync(string document, IEnumerable<StudentSubject> subjectCodes)
        {
            //Remove previus
            var subjectsPrevius = _context.StudentSubjects.Where(u => u.StudentDocument == document);
            foreach (var code in subjectsPrevius)
            {
                _context.StudentSubjects.Remove(code);
            }

            //Add new
            foreach (var code in subjectCodes)
            {
                _context.StudentSubjects.Add(code);
            }

            await _context.SaveChangesAsync();
        }
    }
}
