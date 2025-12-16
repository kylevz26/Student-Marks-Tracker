using Microsoft.AspNetCore.Mvc;
using StudentMarksTracker.Services;
using StudentMarksTracker.Models;
using Microsoft.Identity.Client;

namespace StudentMarksTracker.Controllers
{
    public class MarksController : Controller
    {
        private readonly IMarksService _marksService;   //creating Interface variable (Dependency Inversion)

        public MarksController(IMarksService marksService)  //constructor
        {
            _marksService = marksService;
        }

        //Home Page will show ALL marks
        public async Task<IActionResult> Index()
        {
            var marks = await _marksService.GetAllMarks();
            return View(marks);
        }

        //Add Mark
        public async Task<IActionResult> Add(int studentId)
        {
            Marks model = new Marks();  //creating a brand new, empty Mark object
            model.StudentId = studentId;    //pre-fill studentId immediately, so we know which student the mark is for
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Marks markToAdd)
        {
            await _marksService.AddMark(markToAdd);

            //once mark is added we redirect back to the specific student's profile/details
            return RedirectToAction("Details", "Student", new { id = markToAdd.StudentId });
        }

        //Edit Mark
        public async Task<IActionResult> Edit(int id)
        {
           var mark = await _marksService.GetMarkById(id);
            if (mark == null)
            {
                ViewBag.Error = "Mark not found";
                return View();
            }

            return View("EditForm", mark);  //This will open the 'EditForm' page and takes the 'mark' data with you so we can display the info
        }
        [HttpPost]
        public async Task<IActionResult> EditForm(Marks markToEdit)
        {
            await _marksService.EditMarkById(markToEdit);
            return RedirectToAction("Details", "Student", new { id = markToEdit.StudentId });
        }

        //Delete Mark
        public async Task<IActionResult> Delete(int id)
        {
            var mark = await _marksService.GetMarkById(id);
            if (mark == null)
            {
                ViewBag.Error = "Mark not found";
                return View();
            }

            return View("DeleteForm", mark);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteForm(int markId)
        {
            var mark = await _marksService.GetMarkById(markId);

            if (mark == null) return RedirectToAction("Index", "Student");  //Safety check in case it's already deleted

            int tempStudentId = mark.StudentId; //We are saving the ID because we are only deleting the mark, NOT THE STUDENT as well

            await _marksService.DeleteMarkById(markId);
            return RedirectToAction("Details", "Student", new { id = tempStudentId });  //Redirect back to that specific Student's profile
        }
    }
}
