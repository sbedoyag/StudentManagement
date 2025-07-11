using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public EditModel(ISubjectService studentService, IMapper mapper)
        {
            _subjectService = studentService;
            _mapper = mapper;
        }

        [BindProperty]
        public SubjectViewModel Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var subject =  await _subjectService.GetByCodeAsync(code);
            if (subject == null)
            {
                return NotFound();
            }
            Subject = _mapper.Map<SubjectViewModel>(subject);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentSubject = await _subjectService.GetByCodeAsync(Subject.Code);
            if (currentSubject == null)
            {
                return NotFound();
            }

            await _subjectService.UpdateAsync(_mapper.Map<Subject>(Subject));

            return RedirectToPage("./Index");
        }
    }
}
