using Microsoft.EntityFrameworkCore;
using University.Models.Entities;

namespace University.Repository.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //1:18:24


    }
}
