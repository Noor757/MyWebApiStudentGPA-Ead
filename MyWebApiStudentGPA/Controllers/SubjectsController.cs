using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly ISubjectDL subjectDL;
        public SubjectsController(ISubjectDL _subjectDL)
        {
            subjectDL = _subjectDL;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                var subjects = subjectDL.GetSubjects();
                return Ok(subjects);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var subject = subjectDL.GetSubject(Id);
                return Ok(subject);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("")]
        public IActionResult Post(SubjectRequestDto subjectRequestDto)
        {
            try
            {
                var subject = subjectDL.SaveSubject(subjectRequestDto);
                return Ok(subject);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{Id}")]
        public IActionResult Edit(int Id, SubjectRequestDto subjectRequestDto)
        {
            try
            {
                var subject = subjectDL.UpdateSubject(Id, subjectRequestDto);
                return Ok(subject);
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
                var subject = subjectDL.DeleteSubject(Id);
                return Ok("Subject Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
