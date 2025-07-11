using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public EditModel(IStudentService studentService, ISubjectService subjectService, IMapper mapper)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _mapper = mapper;
        }


        [BindProperty]
        public StudentViewModel Student { get; set; } = default!;

        [BindProperty]
        public List<string> SelectedSubjectCodes { get; set; } = default!;

        [BindProperty]
        public IEnumerable<SubjectViewModel> AvailableSubjects { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string document)
        {
            if (document == null)
            {
                return NotFound();
            }

            var allSubjects = await _subjectService.GetAllAsync();
            AvailableSubjects = _mapper.Map<IEnumerable<SubjectViewModel>>(allSubjects);
            
            var student = await _studentService.GetByDocumentAsync(document);
            if (student == null)
            {
                return NotFound();
            }
            Student = _mapper.Map<StudentViewModel>(student);
            Student.SelectedSubjectCodes = student.Subjects.Select(subject => subject.SubjectCode);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var subjectCredit = SelectedSubjectCodes.Select(s => s.Split("-")).ToDictionary(d => d[0], d => int.Parse(d[1]));
            var toMuchCredits = subjectCredit.Count(u => u.Value > 3);
            if (toMuchCredits > 3)
            {
                return Page();
            }

            var currentSubject = await _studentService.GetByDocumentAsync(Student.Document);
            if (currentSubject is null)
            {
                return NotFound();
            }

            var student = _mapper.Map<Student>(Student);
            student.Subjects = subjectCredit
                .Select(subject => new StudentSubject
                {
                    Student = student,
                    SubjectCode = subject.Key,
                    StudentDocument = Student.Document,
                }).ToList();

            await _studentService.UpdateAsync(student);

            return RedirectToPage("./Index");
        }
    }
}
