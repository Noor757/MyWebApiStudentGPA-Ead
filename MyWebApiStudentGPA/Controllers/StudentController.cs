using Core.Interfaces;
using Core.Models.RequestModels;
using DL;
using DL.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using MyWebApiStudentGPA.DL;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentDL studentDL;
        public StudentsController(IStudentDL _studentDL)
        {
            studentDL = _studentDL;
        }
        [HttpPost("")]
        public IActionResult Post(StudentRequestDto studentRequestDto)
        {
            try
            {
                var student = studentDL.SaveStudent(studentRequestDto);
                return Ok(student);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{Id}")]
        public IActionResult Edit(int Id, StudentRequestDto studentRequestDto)
        {
            try
            {
                var student = studentDL.UpdateStudent(Id, studentRequestDto);
                return Ok(student);
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
                var student = studentDL.DeleteStudent(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}/Subjects")]
        public IActionResult GetSubjects(int Id)
        {
            try
            {
                var subjects = studentDL.GetSubjects(Id);
                return Ok(subjects);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var students = studentDL.GetStudentsAsync();
            return Ok(students);
        }

    }

}









