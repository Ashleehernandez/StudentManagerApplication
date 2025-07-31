using Microsoft.AspNetCore.Mvc;
using StudentManagerApplication.Applicaction.IService;
using StudentManagerApplication.Domain.Entity;


namespace StudentManagerApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IServiceStudents ServiceStudents;
        public StudentsController(IServiceStudents service)
        {
            ServiceStudents = service ?? throw new ArgumentNullException(nameof(ServiceStudents));
        }
        // GET: api/students

        [HttpPost]
        [Route("Add")] // Esta ruta ya se combina con [Route("api/[controller]")] -> api/students/Add
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            try
            {
                await ServiceStudents.AddStudentAsync(student);
                return Ok("Student added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/students/Update")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            try
            {

                if (student == null || student.Id <= 0)
                {
                    return BadRequest("Invalid student data.");
                }
                await ServiceStudents.UpdateStudentAsync(student);
                return Ok("Student updated successfully.");
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

            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteStudent(int id)
            {
               
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest("Invalid student ID.");
                    }
                    var exists = await ServiceStudents.StudentExistsAsync(id);
                    if (!exists)
                    {
                        return NotFound($"Student with ID {id} not found.");
                    }
                    await ServiceStudents.DeleteStudentAsync(id);
                    return Ok("Student deleted successfully.");
                }
                catch (Exception ex)
                {
                    // Log the exception (not implemented here)
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }
        }

    }
}
