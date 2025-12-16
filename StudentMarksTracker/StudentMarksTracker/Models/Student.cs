namespace StudentMarksTracker.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
        public string StudentEmail { get; set; }

        public List<Marks> Marks { get; set; } = new List<Marks>(); //navigation property

        public Student() { }

        public Student(int id, string name, string surname, int age, string email)
        {
            StudentId = id;
            StudentName = name;
            StudentSurname = surname;
            StudentAge = age;
            StudentEmail = email;
        }
    }
}
