using DAL.Entities;
using DAL.Reposibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class MemberService
    {
        private MemberRepo _accountrepo = new();

        public List<Member> GetAllAccount()
        {
            return _accountrepo.GetAllAccount();
        }

        public List<Member> Search(string keyword)
        {
            return _accountrepo.Search(keyword);
        }
        public List<Member> Create(Member member)
        {
            return _accountrepo.Create(member);
        }
        public List<Member> Update(Member member)
        {
            return _accountrepo.Update(member);
        }
    }
}
