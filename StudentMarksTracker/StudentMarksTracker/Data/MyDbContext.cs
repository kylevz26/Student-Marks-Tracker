using StudentMarksTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentMarksTracker.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions options) : base(options)    // Adding this to let ASP.NET inject configuration
        {
        }

        //creating the Db Sets (tables in database)
        //Student Table
        public DbSet<Student> Students { get; set; }

        //Marks Table
        public DbSet<Marks> Marks { get; set; }
    }
}
