using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByDocumentAsync(string document);
        Task CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(string document);
        Task AddSubjectAsync(string document, Subject subject);
    }
}
