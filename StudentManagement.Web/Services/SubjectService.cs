using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Repositories;
using StudentManagement.Core.Interfaces.Services;

namespace StudentManagement.Web.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task CreateAsync(Subject subject)
        {
            await _subjectRepository.CreateAsync(subject);
        }

        public async Task<Subject?> GetByCodeAsync(string code)
        {
            return await _subjectRepository.GetByCodeAsync(code);
        }

        public async Task UpdateAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteAsync(Subject subject)
        {
            await _subjectRepository.DeleteAsync(subject);
        }
    }
}
