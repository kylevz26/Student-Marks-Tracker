using StudentMarksTracker.Models;
namespace StudentMarksTracker.Services
{
    public interface IMarksService
    {
        //CRUD Methods for dealing with Marks
        public Task AddMark(Marks markToAdd);
        public Task<Marks> GetMarkById(int id);
        public Task EditMarkById(Marks markToEdit);
        public Task DeleteMarkById(int markId);
        public Task<List<Marks>> GetAllMarks();
    }
}
