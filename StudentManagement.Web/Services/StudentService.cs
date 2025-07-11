using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;
using StudentManagement.Core.Interfaces.Services;

namespace StudentManagement.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByDocumentAsync(string document)
        {
            return await _studentRepository.GetByDocumentAsync(document);
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);
        }
    }
}
