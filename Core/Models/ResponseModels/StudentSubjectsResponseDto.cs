using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class StudentSubjectsResponseDto : IStudentSubjects
    {
        public int Id { get; set; }
        public int SID { get; set; }
        public int SubjectId { get; set; }
        public double GPA { get; set; }
    }
}
