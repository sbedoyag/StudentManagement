﻿namespace StudentManagement.Core.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}