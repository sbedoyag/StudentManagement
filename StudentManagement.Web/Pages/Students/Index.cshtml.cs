using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Core.Interfaces.Services;
using StudentManagement.Web.Services.DTOs;

namespace StudentManagement.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;
        public IEnumerable<StudentViewModel> Students { get; set; }
        
        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task OnGet()
        {
            var students = await _studentService.GetAllAsync();
            Students = students.Select(s => new StudentViewModel
            {
                Name = s.Name,
                Email = s.Email,
                Document = s.Document
            });
        }
    }
}
