using DAL.Entities;
using DAL.Reposibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UserAccountService
    {
        private UserAccountRepo _userAccountRepo = new();
        public UserAccount? Authenticate (string username, string password)
        {
            return _userAccountRepo.GetOne(username, password);
        }
    }
}
