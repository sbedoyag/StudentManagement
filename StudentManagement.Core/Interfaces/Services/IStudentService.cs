using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByDocumentAsync(string document);
        Task CreateAsync(Student student);
    }
}
