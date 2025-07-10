using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task AddSubjectAsync(int studentId, Subject subject);
    }
}
