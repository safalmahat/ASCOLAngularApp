using DataAccessLayer.Model;
using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Service
{
    public interface IUserService
    {
        User GetUser(string userName, string password);
        List<UserAndRoleModel> GetRolesByUserId(int id);
    }
    public class UserService : IUserService
    {
        private IUserRepo _userRepo;
        private IUserRoleRepo _userRoleRepo;
        public UserService(IUserRepo userRepo, IUserRoleRepo userRoleRepo)
        {
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
        }

        public List<UserAndRoleModel> GetRolesByUserId(int id)
        {
            return _userRoleRepo.GetRolesByUserId(id);
        }

        public User GetUser(string userName, string password)
        {
            return _userRepo.GetUser(userName, password);
        }
    }
}
