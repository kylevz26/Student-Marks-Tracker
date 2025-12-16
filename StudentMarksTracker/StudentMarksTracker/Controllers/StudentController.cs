using Microsoft.AspNetCore.Mvc;
using StudentMarksTracker.Models;
using StudentMarksTracker.Services;
using System.Threading.Tasks;

namespace StudentMarksTracker.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;   //creating Interface variable (Dependency Inversion)

        public StudentController(IStudentService studentService)    //constructor
        {
            _studentService = studentService;
        }

        //Home page will show ALL Students
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.ShowAllStudents();
            return View(students);
        }

        //Add Student Page
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student studentToAdd)
        {
            await _studentService.AddStudent(studentToAdd);
            return RedirectToAction("Index");   //takes us back to the Index page
        }

        //Delete Student Page
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                ViewBag.Error = "Student not found";    //if null, an error message will be displayed
                return View();
            }

            return View("DeleteForm", student); //This will open the 'DeleteForm' page and takes the 'student' data with you so we can display their name
        }
        [HttpPost]
        public async Task<IActionResult> DeleteForm(int studentId)
        {
            await _studentService.DeleteStudentById(studentId);
            return RedirectToAction("Index");
        }

        //Update Student Page
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                ViewBag.Error = "Student not found";
                return View();
            }

            return View("UpdateForm", student);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateForm(Student studentToUpdate)
        {
            await _studentService.UpdateStudentById(studentToUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                ViewBag.Error = "Student not found";
                return View();
            }

            return View(student);
        }
    }
}
