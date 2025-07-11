using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public IEnumerable<SubjectViewModel> Subjects { get;set; }

        public IndexModel(ISubjectService studentService, IMapper mapper)
        {
            _subjectService = studentService;
            _mapper = mapper;
        }


        public async Task OnGet()
        {
            var subjects = await _subjectService.GetAllAsync();
            Subjects = _mapper.Map<IEnumerable<SubjectViewModel>>(subjects);
        }
    }
}
