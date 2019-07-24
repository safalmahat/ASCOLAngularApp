using Dapper;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repo
{
    public interface ITeacherRepo
    {
        List<Teacher> GetTeachers();
    }
    public class TeacherRepo : ITeacherRepo
    {
        public List<Teacher> GetTeachers()
        {

            string str = @"Data Source=.;Initial Catalog=FeedBack;Integrated Security=true;";
            List<Teacher> teachers = new List<Teacher>();
            using (var con = new SqlConnection(str))
            {
                teachers = con.Query<Teacher>("select * from TeacherInfo").ToList();
            }
            return teachers;
        }
    }
}
