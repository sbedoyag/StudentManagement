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

        public async Task<Subject?> GetByCodeAsync(string code)
        {
            return await _context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task CreateAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject subject)
        {
            _context.Attach(subject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
