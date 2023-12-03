using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.RequestModels
{
    public class StudentSubjectsRequestDto : IStudentSubjects
    {
        public int SID { get; set; }
        public int SubjectId { get; set; }

        public double GPA { get; set; }
    }
}
