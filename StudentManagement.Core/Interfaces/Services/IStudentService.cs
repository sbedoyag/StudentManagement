using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task CreateAsync(Student student);
    }
}
