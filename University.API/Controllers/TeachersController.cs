using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using University.Models.Entities;
using University.Repository.Data;

namespace University.API.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Teachers.ToListAsync();

            if (result.Count()==0) 
            {
                return NotFound("No teachers found");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTeacher([FromRoute] int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound($"No teacher found with id {id}");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] Teacher teacher) 
        {
           
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok("Upload successfull");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher([FromBody] Teacher teacher)
        {
            var teacherToUpdate = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == teacher.Id);


            teacherToUpdate.Name = teacher.Name;
            teacherToUpdate.Age= teacher.Age;
            teacherToUpdate.Salary= teacher.Salary;

            await _context.SaveChangesAsync();
            return Ok("Update successfull");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
        {
            var teacherToRemove= await _context.Teachers.FirstOrDefaultAsync(x=>x.Id==id);
            if(teacherToRemove == null)
            {
                return BadRequest($"Unable to delete, no teacher found with id {id}");
            }

            _context.Teachers.Remove(teacherToRemove);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }



    }
}
