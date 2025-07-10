using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task CreateAsync(Subject subject);
    }
}
