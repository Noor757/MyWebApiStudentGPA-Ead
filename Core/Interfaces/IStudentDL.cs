using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentDL
    {
        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto);
        public IEnumerable<StudentResponseDto> GetStudentsAsync();
        public StudentResponseDto UpdateStudent(int Id, StudentRequestDto studentRequestDto);
        public StudentResponseDto DeleteStudent(int Id);
        public IEnumerable<SubjectResponseDto> GetSubjects(int Id);

    }
}
