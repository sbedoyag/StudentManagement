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

            //return students.Select(s => new StudentViewModel
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Subjects = s.Subjects.Select(sub => new SubjectViewModel
            //    {
            //        Id = sub.Id,
            //        Name = sub.Name
            //    }).ToList()
            //});
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        //public async Task AddSubjectToStudentAsync(int studentId, Subject subject)
        //{
        //    await _studentRepository.AddSubjectAsync(studentId, subject);
        //}
    }
}
