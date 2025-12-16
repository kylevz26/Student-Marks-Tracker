using Microsoft.EntityFrameworkCore;
using StudentMarksTracker.Data;
using StudentMarksTracker.Models;

namespace StudentMarksTracker.Services
{
    public class StudentService: IStudentService
    {
        private readonly MyDbContext _myDbContext;

        public StudentService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task AddStudent(Student studentToAdd)
        {
            _myDbContext.Students.Add(studentToAdd);    //adding new student to database
            await _myDbContext.SaveChangesAsync();      //saving the changes
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _myDbContext.Students.Include(s => s.Marks).FirstOrDefaultAsync(n => n.StudentId == id);   //getting ALL students WITH their marks
        }

        public async Task DeleteStudentById(int studentId)
        {
            var existingStudent = await _myDbContext.Students.FindAsync(studentId); //finding student with that Id
            if (existingStudent != null)
            {
                _myDbContext.Students.Remove(existingStudent);  //removing the student from database
                await _myDbContext.SaveChangesAsync();          //saving the changes
            }

            return;
        }
        public async Task UpdateStudentById(Student studentToUpdate)
        {
            var existingStudent = await _myDbContext.Students.FindAsync(studentToUpdate.StudentId); //finding student with that Id
            if (existingStudent != null)
            {
                existingStudent.StudentName = studentToUpdate.StudentName;              //updating their details
                existingStudent.StudentSurname = studentToUpdate.StudentSurname;
                existingStudent.StudentAge = studentToUpdate.StudentAge;
                existingStudent.StudentEmail = studentToUpdate.StudentEmail;

                await _myDbContext.SaveChangesAsync();          //saving the changes
            }

            return;
        }
        public async Task<List<Student>> ShowAllStudents()
        {
            return await _myDbContext.Students.ToListAsync();
        }

    }
}
