using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Entities;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public IEnumerable<StudentViewModel> Students { get; set; }
        
        public IndexModel(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task OnGet()
        {
            var students = await _studentService.GetAllAsync();
            Students = _mapper.Map<IEnumerable<StudentViewModel>>(students);
            //Students = students.Select(s => new StudentViewModel
            //{
            //    Name = s.Name,
            //    Email = s.Email,
            //    Document = s.Document
            //});
        }
    }
}
