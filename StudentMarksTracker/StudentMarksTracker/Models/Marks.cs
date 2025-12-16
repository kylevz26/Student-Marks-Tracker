namespace StudentMarksTracker.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public double Mark {  get; set; }

        public int StudentId { get; set; }      //foreign key
        public Student student { get; set; }    //navigation property

        public Marks() { }
        public Marks(int id, string subject, double mark, int studentId)
        {
            Id = id;
            Subject = subject;
            Mark = mark;
            StudentId = studentId;
        }
    }
}
