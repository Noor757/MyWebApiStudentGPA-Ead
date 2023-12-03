using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentSubjectsDL
    {
        public StudentSubjectsResponseDto SaveStudentSubjects(StudentSubjectsRequestDto studentSubjectsRequestDto);
        public StudentSubjectsResponseDto DeleteStudentSubjects(int Id);
        public StudentSubjectsResponseDto UpdateStudentSubjects(int Id, StudentSubjectsRequestDto studentSubjectsRequestDto);

    }
}
