using StudentMarksTracker.Models;
using System.ComponentModel;

namespace StudentMarksTracker.Services
{
    public interface IStudentService
    {
        //CRUD Methods
        public Task AddStudent(Student studentToAdd);
        public Task<Student> GetStudentById(int id);
        public Task DeleteStudentById(int studentId);
        public Task UpdateStudentById(Student studentToUpdate);
        public Task<List<Student>> ShowAllStudents();
    }
}
