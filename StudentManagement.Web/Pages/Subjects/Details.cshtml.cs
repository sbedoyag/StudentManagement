using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Subjects
{
    public class DetailsModel : PageModel
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public DetailsModel(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

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
    }
}
