namespace StudentManagement.Core.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public bool IsActive { get; set; }
    }
}