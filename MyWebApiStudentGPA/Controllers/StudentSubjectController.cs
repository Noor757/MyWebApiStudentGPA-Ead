using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : Controller
    {
        private readonly IStudentSubjectsDL _studentSubjectsDL;
        public StudentSubjectsController(IStudentSubjectsDL studentSubjectsDL)
        {
            _studentSubjectsDL = studentSubjectsDL;
        }
        [HttpPost("")]
        public IActionResult Post(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            try
            {
                var studentsubject = _studentSubjectsDL.SaveStudentSubjects(studentSubjectsRequestDto);
                return Ok(studentsubject);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            try
            {
                var studentsubject = _studentSubjectsDL.UpdateStudentSubjects(Id, studentSubjectsRequestDto);
                return Ok(studentsubject);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var studentsubject = _studentSubjectsDL.DeleteStudentSubjects(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}