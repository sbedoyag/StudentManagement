using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public DetailsModel(IStudentService studentService, IMapper mapper)
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

            var subject = await _studentService.GetByDocumentAsync(document);

            if (subject is not null)
            {
                Student = _mapper.Map<StudentViewModel>(subject);

                return Page();
            }

            return NotFound();
        }
    }
}
