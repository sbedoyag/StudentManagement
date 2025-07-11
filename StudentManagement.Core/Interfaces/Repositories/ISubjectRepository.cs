using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject?> GetByCodeAsync(string code);
        Task CreateAsync(Subject subject);
        Task UpdateAsync(Subject subject);
        Task DeleteAsync(string code);
    }
}
