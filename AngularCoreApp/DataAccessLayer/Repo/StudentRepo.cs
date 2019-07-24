using Dapper;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repo
{
    public interface IStudentRepo
    {
        List<Student> GetAllStudent();
        void Insert(Student student);
        Student GetStudentById(int id);
        void Edit(Student item);
    }


    public class StudentRepo : IStudentRepo
    {
        private IDatabaseManager _databaseManager;
        public StudentRepo(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }
        public List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            using (var con = _databaseManager.GetConnection())
            {
                students = con.Query<Student>("select * from StudentInfo").ToList();
            }
            return students;
        }
        public void Insert(Student student)
        {
            using (var con = _databaseManager.GetConnection())
            {
                string strQuery = @"INSERT INTO STUDENTINFO(Name,Address,PhoneNumber,Email,Gender,EnrolledDate,TeacherId)VALUES
(@Name,@Address,@PhoneNumber,@Email,@Gender,@EnrolledDate,@TeacherId)";

                con.Execute(strQuery, student);
            }
        }
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            string strQuery = "SELECT  * FROM STUDENTINFO WHERE ID=@ID";
            string str = @"Data Source=.;Initial Catalog=FeedBack;Integrated Security=true;";
            using (var con = new SqlConnection(str))
            {
                student = con.Query<Student>(strQuery, new { Id = id }).SingleOrDefault();
            }
            return student;
        }
        public void Edit(Student item)
        {
            string strQuery = @"UPDATE STUDENTINFO SET Name=@Name,Address=@Address,PhoneNumber=@PhoneNumber,Email=@Email,Gender=@Gender,EnrolledDate=@EnrolledDate,TeacherId=@TeacherId WHERE ID=@ID";
            string str = @"Data Source=.;Initial Catalog=FeedBack;Integrated Security=true;";
            using (var con = new SqlConnection(str))
            {
                con.Execute(strQuery, item);
            }
        }
    }
}
