using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zest_DotNet_Assessment.Model;
using Zest_DotNet_Assessment.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Zest_DotNet_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _std;

        public StudentController(StudentRepository std)
        {
            _std = std;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _std.GetAllStudent();
            return Ok(students);
        }

        [HttpPost("InsertStudent")]
        public IActionResult InsertStudent([FromBody] StudentModel std)
        {
            if (std == null)
                return BadRequest("student data is null");
            bool Result = _std.InsertStudent(std);
            if (Result)
                return Ok("Student inserted successfully");
            else
                return StatusCode(500, "An error occurred while inserting the student");
        }

        [HttpGet("GetStudentByID/{ID}")]
        public IActionResult GetStudentByID(string ID)
        {
            var student = _std.Get_Student_By_ID(ID);
            if (student == null)
                return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost("UpdateStudent/{ID}")]
        public IActionResult UpdateStudent(string ID, [FromBody] StudentModel std)
        {
            if (std == null)
                return BadRequest("student data is null");
            bool Result = _std.UpdateStudent(std);
            if (Result)
                return Ok("Student updated successfully");
            else
                return StatusCode(500, "An error occurred while updating the student");
        }

        [HttpPost("DeleteStudent/{ID}")]
        public IActionResult DeleteStudent(string ID)
        {
            bool Result = _std.DeleteStudent(ID);
            if (Result)
                return Ok("Student deleted successfully");
            else
                return StatusCode(500, "An error occurred while deleting the student");
        }
    }
}
