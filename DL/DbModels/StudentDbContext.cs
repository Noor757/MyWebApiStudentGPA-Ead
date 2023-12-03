using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class StudentDbContext : DbContext
    {
        public DbSet <StudentDbDto> studentDbDto { get; set; }
        public DbSet<SubjectDbDto> subjectDbDto { get; set; }

        public DbSet<StudentSubjectDbDto> studentSubjectDbDto { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=TAYYAB\\SQLEXPRESS;Database=StudentCourse;User ID=sa;Password=123; Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDbDto>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SubjectDbDto>()
                .HasKey(e => e.id);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasKey(sc => new { sc.SID, sc.SubjectId }); 

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(sc => sc.studentDbDto)
                .WithMany(s => s.studentSubjects)
                .HasForeignKey(sc => sc.Id);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(sc => sc.subjectDbDto)
                .WithMany(sub => sub.StudentSubjects)
                .HasForeignKey(sc => sc.SubjectId);

            modelBuilder.Entity<StudentDbDto>().HasMany<StudentSubjectDbDto>()
            .WithOne(sc => sc.studentDbDto);

            modelBuilder.Entity<SubjectDbDto>().HasMany<StudentSubjectDbDto>()
                .WithOne(sc => sc.subjectDbDto);
        }

    }

}
