using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public CreateModel(ISubjectService studentService, IMapper mapper)
        {
            _subjectService = studentService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SubjectViewModel Subject { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _subjectService.CreateAsync(_mapper.Map<Subject>(Subject));

            return RedirectToPage("./Index");
        }
    }
}
