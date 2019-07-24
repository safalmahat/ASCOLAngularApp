using DataAccessLayer.Model;
using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Service
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
    }
    public class TeacherService : ITeacherService
    {
        private ITeacherRepo _teacherRepo;
        public TeacherService(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        public List<Teacher> GetTeachers()
        {
            return _teacherRepo.GetTeachers();
        }
    }
}
