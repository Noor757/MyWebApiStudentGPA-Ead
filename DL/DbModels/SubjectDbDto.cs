using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    [Table("SubjectDbDto2")]
    public class SubjectDbDto
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        public ICollection<StudentSubjectDbDto> StudentSubjects { get; set; } = new List<StudentSubjectDbDto>();
    }
}
