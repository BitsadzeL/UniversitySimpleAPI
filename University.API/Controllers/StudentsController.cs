using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Models.Entities;
using University.Repository.Data;

namespace University.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentsController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var students = await _context.Students.ToListAsync();

            if (students.Count() == 0)
            {
                return NotFound("No students found");
            }
            return Ok(students);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleStudent([FromRoute]int id)
        {
            var result=await  _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(result == null)
            {
                return NotFound($"No student found with id {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {

            Student studentToInsert=new Student()
            {
                Name = student.Name,
                PersonalNumber = student.PersonalNumber,
                Email = student.Email,
                BirthDate= student.BirthDate,
            };

            await _context.Students.AddAsync(studentToInsert);
            await _context.SaveChangesAsync();
            return Ok("Uploaded successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var studentToDelete=_context.Students.FirstOrDefault(x=>x.Id == id);

            if(studentToDelete == null)
            {
                return BadRequest($"Unable to delete. No student found with id {id}"); 
            }

            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {

            var studentToUpdate = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            studentToUpdate.Name = student.Name;
            studentToUpdate.PersonalNumber = student.PersonalNumber;
            studentToUpdate.Email = student.Email;
            studentToUpdate.BirthDate = student.BirthDate;

            await _context.SaveChangesAsync();
            return Ok("Updated successfully");
        }







    }
}
