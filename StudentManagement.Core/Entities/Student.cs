using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Core.Entities
{
    public class Student
    {
        [Key]
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<StudentSubject> Subjects { get; set; }
    }
}