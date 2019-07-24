using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Service;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCoreApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetAllStudent()
        {

            return Ok(_studentService.GetAllStudents());
        }
        [HttpPost]
        public IActionResult Insert(Student student)
        {
            if (student.Id > 0)
                _studentService.Edit(student);
            else
            _studentService.Insert(student);
                return Ok();
        }
        [HttpGet("GetStudentById")]
        public  IActionResult GetStudentById(int id)
        {
            return Ok(_studentService.GetStudentById(id));
        }
    }
}