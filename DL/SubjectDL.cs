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
    public class SubjectDL : ISubjectDL
    {
        StudentDbContext _studentDbContext;
        public SubjectDL(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto)
        {
            if (subjectRequestDto.Name == null || string.IsNullOrEmpty(subjectRequestDto.Name.Trim()))
            {
                throw new Exception("Subject Name is required");
            }
            if (subjectRequestDto.Name.Length > 50 || subjectRequestDto.Name.Length < 3 || int.TryParse(subjectRequestDto.Name, out _))
            {
                throw new Exception("Subject Name is invalid");
            }
            var newSubject = new SubjectDbDto
            {
                Name = subjectRequestDto.Name,
            };
            _studentDbContext.subjectDbDto.Add(newSubject);
            _studentDbContext.SaveChanges();
            return new SubjectResponseDto
            {
                Id = newSubject.id,
                Name = newSubject.Name,
            };

        }
        public IEnumerable<SubjectResponseDto> GetSubjects()
        {
            var subjects = _studentDbContext.subjectDbDto.ToList();
            var subjectResponseDto = subjects.Select(x => new SubjectResponseDto
            {
                Id = x.id,
                Name = x.Name,
            });
            return subjectResponseDto;
        }

        public SubjectResponseDto GetSubject(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var subject = _studentDbContext.subjectDbDto.FirstOrDefault(x => x.id == id);
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }
            return new SubjectResponseDto
            {
                Id = subject.id,
                Name = subject.Name,
            };
        }

        public SubjectResponseDto UpdateSubject(int Id, SubjectRequestDto subjectRequestDto)
        {
            if (Id <= 0)
            {
                throw new Exception("Id is not valid");
            }

            var subject = _studentDbContext.subjectDbDto.FirstOrDefault(x => x.id == Id);
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }
            if (subjectRequestDto.Name == null || string.IsNullOrEmpty(subjectRequestDto.Name.Trim()) || int.TryParse(subjectRequestDto.Name, out _))
            {
                throw new Exception("Subject name is required");
            }
            if (subjectRequestDto.Name.Length > 50 || subjectRequestDto.Name.Length < 3)
            {
                throw new Exception("Subject Name is invalid");
            }
            subject.Name = subjectRequestDto.Name;
            _studentDbContext.SaveChanges();
            return new SubjectResponseDto
            {
                Id = subject.id,
                Name = subject.Name,
            };
        }

        public SubjectResponseDto DeleteSubject(int Id)
        {
            if (Id <= 0)
            {
                throw new Exception("Id is not valid");
            }
            var subject = _studentDbContext.subjectDbDto.FirstOrDefault(x => x.id == Id);
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }
            _studentDbContext.subjectDbDto.Remove(subject);
            _studentDbContext.SaveChanges();
            return new SubjectResponseDto
            {
                Id = subject.id,
                Name = subject.Name,
            };
        }
    }
}
