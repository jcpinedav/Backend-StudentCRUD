using BackEnd_Students.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace BackEnd_Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listStudents = await _context.Students.ToListAsync();
                return Ok(listStudents);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get( int id)
        {
            try
            {
                var Student = await _context.Students.FindAsync(id);
                if(Student == null)
                {
                    return NotFound();
                }
                return Ok(Student);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Student = await _context.Students.FindAsync(id);
                if (Student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            try
            {
                student.CreationDate = DateTime.Now;
                _context.Add(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = student.Id}, student);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id,Student student)
        {
            try
            {
                if(id != student.Id)
                {
                    return BadRequest();
                }

                var studentItem = await _context.Students.FindAsync(id);
                if (studentItem == null)
                {
                    return NotFound();
                }

                studentItem.Name = student.Name;
                studentItem.Email = student.Email;
                studentItem.Age = student.Age;
                studentItem.Gender = student.Gender;
                studentItem.CurrentCourse = student.CurrentCourse;

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
