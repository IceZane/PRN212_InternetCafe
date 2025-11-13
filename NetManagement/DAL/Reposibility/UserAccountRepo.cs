using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposibility
{
    public class UserAccountRepo
    {
        private NetManagementDbContext _account;
        public UserAccount? GetOne(string username, string password)
        {
            _account = new();
            return _account.UserAccounts.FirstOrDefault(x =>x.UserName.ToLower()== username.ToLower()  && x.Password == password);
        }
    }
}
