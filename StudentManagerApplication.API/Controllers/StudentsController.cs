using Microsoft.AspNetCore.Mvc;
using StudentManagerApplication.Applicaction.IService;
using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IServiceStudents serviceStudents;

        public StudentsController(IServiceStudents service)
        {
            serviceStudents = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("api/students/Get")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await serviceStudents.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await serviceStudents.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/students/Add")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student data is null.");
                }
                await serviceStudents.AddStudentAsync(student);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/students/Update")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student data is null.");
                }
                await serviceStudents.UpdateStudentAsync(student);
                var updatedStudent = await serviceStudents.GetStudentByIdAsync(student.Id);
                // Replace this line:
                // var updatedStudent = await serviceStudents.UpdateStudentAsync(student);

               
                if (updatedStudent == null)
                {
                    return NotFound($"Student with ID {student.Id} not found.");
                }
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID must be greater than zero.");
                }
                await serviceStudents.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }

}
