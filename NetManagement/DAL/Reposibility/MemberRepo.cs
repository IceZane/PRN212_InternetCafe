using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposibility
{
    public class MemberRepo
    {
        private NetManagementDbContext _account;

        public List<Member> GetAllAccount()
        {

            _account = new();
            
            return _account.Members.ToList();
        }
        public List<Member> Search(string keyword)
        {
            _account = new();
            return _account.Members.Where(m => m.AccountName.ToLower().Contains(keyword.ToLower()) || m.FullName.ToLower().Contains(keyword.ToLower()) || (m.Phone != null && m.Phone.ToLower().Contains(keyword.ToLower()))).ToList();
        }
    }
}
