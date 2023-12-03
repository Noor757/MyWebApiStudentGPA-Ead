using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentSubjectsDL : IStudentSubjectsDL
    {
        StudentDbContext _studentcontext;
        public StudentSubjectsDL(StudentDbContext studentDbContext)
        {
            _studentcontext = studentDbContext;
        }

        public StudentSubjectsResponseDto SaveStudentSubjects(StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            if (studentSubjectsRequestDto.SubjectId == default || studentSubjectsRequestDto.SID == default)
            {
                throw new Exception("Student and Subject details are not provided");
            }
            var student = _studentcontext.studentDbDto.Where(x => x.Id == studentSubjectsRequestDto.SID).FirstOrDefault();
            var subject = _studentcontext.subjectDbDto.Where(x => x.id == studentSubjectsRequestDto.SubjectId).FirstOrDefault();
            if (student == null)
            {
                throw new Exception("Student doesn't exist");
            }
            if (subject == null)
            {
                throw new Exception("Subject doesn't exist");
            }
            var studentSubjectCombination = _studentcontext.studentSubjectDbDto.Where(x => x.SID == studentSubjectsRequestDto.SID && x.SubjectId == studentSubjectsRequestDto.SubjectId).FirstOrDefault();
            if (studentSubjectCombination != null)
            {
                throw new Exception("Student and Subject combination already exists");
            }
            var studentSubject = new StudentSubjectDbDto()
            {
                SID = studentSubjectsRequestDto.SID,
                SubjectId = studentSubjectsRequestDto.SubjectId,
                GPA = studentSubjectsRequestDto.GPA,
            };
            _studentcontext.studentSubjectDbDto.Add(studentSubject);
            _studentcontext.SaveChanges();
            return new StudentSubjectsResponseDto()
            {
                Id = studentSubject.Id,
                SID = studentSubject.SID,
                SubjectId = studentSubject.SubjectId,
                GPA = studentSubject.GPA,
            };

        }
        public StudentSubjectsResponseDto DeleteStudentSubjects(int Id)
        {
            if (Id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var studentSubject = _studentcontext.studentSubjectDbDto.Where(x => x.Id == Id).FirstOrDefault();
            if (studentSubject == null)
            {
                throw new Exception("Student and Subject combination not found");
            }
            _studentcontext.studentSubjectDbDto.Remove(studentSubject);
            _studentcontext.SaveChanges();
            return new StudentSubjectsResponseDto()
            {
                Id = studentSubject.Id,
                SID = studentSubject.SID,
                SubjectId = studentSubject.SubjectId,
                GPA = studentSubject.GPA,
            };
        }

        public StudentSubjectsResponseDto UpdateStudentSubjects(int Id, StudentSubjectsRequestDto studentSubjectsRequestDto)
        {
            if (Id <= 0)
            {
                throw new Exception("Id is not valid");
            }

            var studentSubject = _studentcontext.studentSubjectDbDto.Where(x => x.Id == Id).FirstOrDefault();
            if (studentSubject == null)
            {
                throw new Exception("Student and Subject combination not found");
            }

            if (studentSubjectsRequestDto.SID != default)
            {
                var student = _studentcontext.studentDbDto.Where(x => x.Id == studentSubjectsRequestDto.SID).FirstOrDefault();
                if (student == null)
                {
                    throw new Exception("Student doesn't exist");
                }
            }
            if (studentSubjectsRequestDto.SubjectId != default)
            {
                var subject = _studentcontext.subjectDbDto.Where(x => x.id == studentSubjectsRequestDto.SubjectId).FirstOrDefault();
                if (subject == null)
                {
                    throw new Exception("Subject doesn't exist");
                }
            }

            studentSubject.SID = studentSubjectsRequestDto.SID != default ? studentSubjectsRequestDto.SID : studentSubject.SID;
            studentSubject.SubjectId = studentSubjectsRequestDto.SubjectId != default ? studentSubjectsRequestDto.SubjectId : studentSubject.SubjectId;
            studentSubject.GPA = studentSubjectsRequestDto.GPA != default ? studentSubjectsRequestDto.GPA : studentSubject.GPA;
            var studentSubjectCombination = _studentcontext.studentSubjectDbDto.Where(x => x.SID == studentSubject.SID && x.SubjectId == studentSubject.SubjectId).FirstOrDefault();
            if (studentSubjectCombination != null)
            {
                throw new Exception("Student and Subject combination already exists");
            }

            _studentcontext.SaveChanges();

            return new StudentSubjectsResponseDto()
            {
                Id = studentSubject.Id,
                SID = studentSubject.SID,
                SubjectId = studentSubject.SubjectId,
                GPA = studentSubject.GPA,
            };
        }


    }
}
