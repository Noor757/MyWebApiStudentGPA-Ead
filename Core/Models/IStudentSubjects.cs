using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IStudentSubjects
    {
        int SID { get; set; }
        int SubjectId { get; set; }
        double GPA { get; set; }
    }
}
