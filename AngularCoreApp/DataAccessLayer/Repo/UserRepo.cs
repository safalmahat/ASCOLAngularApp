using Dapper;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repo
{
    public interface IUserRepo
    {
        User GetUser(string userName, string password);
    }
    public class UserRepo : IUserRepo
    {
        private IDatabaseManager _databaseManager;
        public UserRepo(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }
        public User GetUser(string userName, string password)
        {
            User user = null;
            using (var con = _databaseManager.GetConnection())
            {
                user = con.QuerySingleOrDefault<User>(@"
select * from UserInfo
where UserName=@UserName and Password=@Password
", new { UserName = userName, Password = password });
            }
            return user;
        }
       
    }
}
