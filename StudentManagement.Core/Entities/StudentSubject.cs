namespace StudentManagement.Core.Entities
{
    public class StudentSubject
    {
        public string StudentDocument { get; set; }
        public Student Student { get; set; }
        public string SubjectCode { get; set; }
        public Subject Subject { get; set; }
    }
}