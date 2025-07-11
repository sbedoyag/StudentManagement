using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public CreateModel(IStudentService studentService, ISubjectService subjectService, IMapper mapper)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            var allSubjects = await _subjectService.GetAllAsync();
            AvailableSubjects = _mapper.Map<IEnumerable<SubjectViewModel>>(allSubjects);
            return Page();
        }


        //public IEnumerable<SubjectViewModel> AvailableSubjects { get; set; } = new List<SubjectViewModel>();

        [BindProperty]
        public StudentViewModel Student { get; set; } = new StudentViewModel();
        
        [BindProperty]
        public List<string> SelectedSubjectCodes { get; set; } = default!;
        
        [BindProperty]
        public IEnumerable<SubjectViewModel> AvailableSubjects { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var subjectToCreate = _mapper.Map<Student>(Student);
            subjectToCreate.Subjects = SelectedSubjectCodes
                .Select(subject => new StudentSubject 
                {
                    SubjectCode = subject,
                    StudentDocument = Student.Document,
                }).ToList();

            await _studentService.CreateAsync(subjectToCreate);

            return RedirectToPage("./Index");
        }
    }
}
