using DataAccessLayer.Model;
using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Service
{
    public interface IUserRoleService
    {
        List<UserAndRoleModel> GetRolesByUserId(int id);
    }
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepo _userRoleRepo;
        public UserRoleService(IUserRoleRepo userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }
        public List<UserAndRoleModel> GetRolesByUserId(int id)
        {
           return _userRoleRepo.GetRolesByUserId(id);
        }
    }
}
