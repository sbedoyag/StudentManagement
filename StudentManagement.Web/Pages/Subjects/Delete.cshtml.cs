using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public DeleteModel(ISubjectService studentService, IMapper mapper)
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

            var subject = await _subjectService.GetByCodeAsync(code);

            if (subject is not null)
            {
                Subject = _mapper.Map<SubjectViewModel>(subject);

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

            var subject = await _subjectService.GetByCodeAsync(code);
            if (subject != null)
            {
                await _subjectService.DeleteAsync(_mapper.Map<Subject>(subject));
            }

            return RedirectToPage("./Index");
        }
    }
}
