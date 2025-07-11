using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task CreateAsync(Subject subject);
        Task<Subject?> GetByCodeAsync(string code);
        Task UpdateAsync(Subject subject);
        Task DeleteAsync(Subject subject);
    }
}
