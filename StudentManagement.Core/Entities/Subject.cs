using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Core.Entities
{
    public class Subject
    {

        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}