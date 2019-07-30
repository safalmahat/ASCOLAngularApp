using Dapper;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repo
{
    public interface IUserRoleRepo
    {
        List<UserAndRoleModel> GetRolesByUserId(int id);
    }
 public   class UserRoleRepo: IUserRoleRepo
    {
        private IDatabaseManager _databaseManager;
        public UserRoleRepo(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }
        public List<UserAndRoleModel> GetRolesByUserId(int id)
        {
            List<UserAndRoleModel> roles = new List<UserAndRoleModel>();
            using (var con = _databaseManager.GetConnection())
            {
                roles = con.Query<UserAndRoleModel>(@"
select ur.Name as 'Role' from UserRoleInfo uri 
left join UserInfo u on u.Id=uri.UserId
left join UserRole ur on ur.Id=uri.UserRoleId
where uri.UserId=@UserId
", new { UserId = id }).ToList();
            }
            return roles;
        }
    }
}
