using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public DeleteModel(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [BindProperty]
        public StudentViewModel Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string document)
        {
            if (document == null)
            {
                return NotFound();
            }

            var students = await _studentService.GetByDocumentAsync(document);

            if (students is not null)
            {
                Student = _mapper.Map<StudentViewModel>(students);

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetByDocumentAsync(code);
            if (student != null)
            {
                await _studentService.DeleteAsync(_mapper.Map<Student>(student));
            }

            return RedirectToPage("./Index");
        }
    }
}
