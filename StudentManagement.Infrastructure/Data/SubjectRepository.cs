using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;

namespace StudentManagement.Infrastructure.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentManagementDbContext _context;

        public SubjectRepository(StudentManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
        }

        public async Task UpdateAsync(Subject subject)
        {
        }

        public async Task DeleteAsync(int id)
        {
        }
    }
}
