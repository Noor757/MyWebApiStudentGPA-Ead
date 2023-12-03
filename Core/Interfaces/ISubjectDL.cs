using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubjectDL
    {
        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto);
        public IEnumerable<SubjectResponseDto> GetSubjects();
        public SubjectResponseDto GetSubject(int id);
        public SubjectResponseDto UpdateSubject(int Id, SubjectRequestDto subjectRequestDto);
        public SubjectResponseDto DeleteSubject(int Id);

    }
}
