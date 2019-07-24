using DataAccessLayer.Model;
using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void Insert(Student student);
        Student GetStudentById(int id);
        void Edit(Student item);
    }
   public  class StudentService: IStudentService
    {
        IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public List<Student> GetAllStudents()
        { 
           return _studentRepo.GetAllStudent();
        }

        public void Insert(Student student)
        {
           // student.CourseId = "1";
            _studentRepo.Insert(student);
        }
        public Student GetStudentById(int id)
        {
            return _studentRepo.GetStudentById(id);
        }

        public void Edit(Student item)
        {
            _studentRepo.Edit(item);
        }
    }
}
