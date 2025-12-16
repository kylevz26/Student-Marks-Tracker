using Microsoft.EntityFrameworkCore;
using StudentMarksTracker.Data;
using StudentMarksTracker.Models;

namespace StudentMarksTracker.Services
{
    public class MarksService : IMarksService
    {
        private readonly MyDbContext _myDbContext;

        public MarksService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;     
        }

        public async Task AddMark(Marks markToAdd)
        {
            _myDbContext.Marks.Add(markToAdd);          //adding new mark
            await _myDbContext.SaveChangesAsync();      //saving changes
        }

        public async Task<Marks> GetMarkById(int id)
        {
            return await _myDbContext.Marks.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task EditMarkById(Marks markToEdit)
        {
            var existingMark = await _myDbContext.Marks.FindAsync(markToEdit.Id);   //finding mark with given Id
            if (existingMark != null)
            {
                existingMark.Subject = markToEdit.Subject;      //updating details
                existingMark.Mark = markToEdit.Mark;
                existingMark.StudentId = markToEdit.StudentId;

                await _myDbContext.SaveChangesAsync();          //saving changes
            }

            return;
        }
        public async Task DeleteMarkById(int markId)
        {
            var existingMark = await _myDbContext.Marks.FindAsync(markId);      //finding mark with given Id
            if (existingMark != null)
            {
                _myDbContext.Marks.Remove(existingMark);    //deleting mark
                await _myDbContext.SaveChangesAsync();      //updating changes
            }

            return;
        }
        public async Task<List<Marks>> GetAllMarks()
        {
            return await _myDbContext.Marks.ToListAsync();      //returning ALL marks in List format
        }
    }
}
