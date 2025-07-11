using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;

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
                .Include(s => s.Subjects)
                .FirstOrDefaultAsync(s => s.Document == document);
        }

        public async Task CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public Task DeleteAsync(string document)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task AddSubjectAsync(string document, Subject subject)
        {
            var studentSubject = new StudentSubject
            {
                StudentDocument = document,
                SubjectCode = subject.Code
            };
            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
        }
    }
}
