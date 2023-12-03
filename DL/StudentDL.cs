using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }


        public IEnumerable<StudentResponseDto> GetStudentsAsync()
        {
            var studentList = _stContext.studentDbDto.ToList();
            var studentResponseList = new List<StudentResponseDto>();
            foreach (var student in studentList)
            {
                studentResponseList.Add(new StudentResponseDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    PhoneNumber = student.PhoneNumber,
                    RollNo = student.RollNumber,
                });
            }
            return studentResponseList;
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {

            if (string.IsNullOrEmpty(studentRequestDto.Name) || string.IsNullOrEmpty(studentRequestDto.PhoneNumber) || string.IsNullOrEmpty(studentRequestDto.RollNo))
            {
                throw new Exception("All Fields are Required");
            }
            if (int.TryParse(studentRequestDto.Name, out _) || studentRequestDto.Name.Length < 5 || studentRequestDto.Name.Length > 20)
            {
                throw new Exception("Invalid Name");
            }
            if (!Regex.IsMatch(studentRequestDto.PhoneNumber, @"^\d{11}$"))
            {
                throw new Exception("Invalid Phone Number");
            }
            if (studentRequestDto.RollNo.Length != 10)
            {
                throw new Exception("Invalid Roll Number");
            }

            var existingStudent = _stContext.studentDbDto.FirstOrDefault(x => x.RollNumber == studentRequestDto.RollNo);
            if (existingStudent != null)
            {
                throw new Exception("Student already exists with this Roll Number");
            }

            var newStudentRecord = new StudentDbDto
            {
                Name = studentRequestDto.Name,
                PhoneNumber = studentRequestDto.PhoneNumber,
                RollNumber = studentRequestDto.RollNo,
            };
            _stContext.studentDbDto.Add(newStudentRecord);
            _stContext.SaveChanges();
            return new StudentResponseDto
            {
                Id = newStudentRecord.Id,

                Name = newStudentRecord.Name,
                PhoneNumber = newStudentRecord.PhoneNumber,
                RollNo = newStudentRecord.RollNumber,

            };

        }

        public StudentResponseDto UpdateStudent(int Id, StudentRequestDto studentRequestDto)
        {
            if (Id <= 0)
            {
                throw new Exception("Invalid Id");
            }

            var student = _stContext.studentDbDto.FirstOrDefault(x => x.Id == Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            if (!string.IsNullOrEmpty(studentRequestDto.Name))
            {
                if (int.TryParse(studentRequestDto.Name, out _) || studentRequestDto.Name.Length < 5 || studentRequestDto.Name.Length > 20)
                {
                    throw new Exception("Invalid Name");
                }
            }
            if (!string.IsNullOrEmpty(studentRequestDto.PhoneNumber))
            {
                if (!Regex.IsMatch(studentRequestDto.PhoneNumber, @"^\d{11}$"))
                {
                    throw new Exception("Invalid Phone Number");
                }
            }
            if (!string.IsNullOrEmpty(studentRequestDto.RollNo))
            {
                if (studentRequestDto.RollNo.Length != 10)
                {
                    throw new Exception("Invalid Roll Number");
                }
                var existingStudent = _stContext.studentDbDto.FirstOrDefault(x => x.RollNumber == studentRequestDto.RollNo);
                if (existingStudent != null)
                {
                    throw new Exception("Student already exists with this Roll Number");
                }
            }

            student.Name = !string.IsNullOrEmpty(studentRequestDto.Name) ? studentRequestDto.Name : student.Name;
            student.PhoneNumber = studentRequestDto.PhoneNumber! ?? student.PhoneNumber;
            student.RollNumber = !string.IsNullOrEmpty(studentRequestDto.RollNo) ? studentRequestDto.RollNo : student.RollNumber;
            _stContext.SaveChanges();
            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                RollNo = student.RollNumber,
            };
        }
        public StudentResponseDto DeleteStudent(int Id)
        {
            if (Id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            var student = _stContext.studentDbDto.FirstOrDefault(x => x.Id == Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            _stContext.studentDbDto.Remove(student);
            _stContext.SaveChanges();
            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                RollNo = student.RollNumber,
            };
        }

        public IEnumerable<SubjectResponseDto> GetSubjects(int Id)
        {
            var student = _stContext.studentDbDto.FirstOrDefault(x => x.Id == Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            var studentSubjectList = _stContext.studentSubjectDbDto.Where(x => x.SID == Id).ToList();
            if (studentSubjectList == null)
            {
                throw new Exception("Student has no subjects");
            }
            var subjectList = new List<SubjectResponseDto>();
            foreach (var studentSubject in studentSubjectList)
            {
                var subject = _stContext.subjectDbDto.FirstOrDefault(x => x.id == studentSubject.SubjectId);
                subjectList.Add(new SubjectResponseDto
                {
                    Id = subject.id,
                    Name = subject.Name,
                });
            }
            return subjectList;
        }

    }
}
