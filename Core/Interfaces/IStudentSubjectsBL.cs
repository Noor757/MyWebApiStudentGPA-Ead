using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace Core.Interfaces
{
    public interface IStudentSubjectsBL
    {
        public StudentSubjectsResponseDto SaveStudentSubjects(StudentSubjectsRequestDto studentSubjectsRequestDto);
        public StudentSubjectsResponseDto DeleteStudentSubjects(int Id);
        public StudentSubjectsResponseDto UpdateStudentSubjects(int Id, StudentSubjectsRequestDto studentSubjectsRequestDto);



    }
}
