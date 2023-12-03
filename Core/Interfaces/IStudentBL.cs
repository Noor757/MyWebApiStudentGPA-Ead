using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentBL
    {
        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto);
        public IEnumerable<StudentResponseDto> GetStudents();
        public StudentResponseDto UpdateStudent(int Id, StudentRequestDto studentRequestDto);
        public StudentResponseDto DeleteStudent(int Id);
        public IEnumerable<SubjectResponseDto> GetSubjects(int Id);
        public decimal GetStudentSubjectMarks(int Id, int SubjectId);
        public double GetStudentGPA(int Id);
    }
}
