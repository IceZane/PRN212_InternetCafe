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

        public void DeleteMember(Member member)
        {
            
            _accountrepo.Delete(member);
        }

        public List<Member> GetAllAccount()
        {
            return _accountrepo.GetAllAccount();
        }

        public List<Member> GetAllComputer()
        {
            throw new NotImplementedException();
        }

        public List<Member> Search(string keyword)
        {
            return _accountrepo.Search(keyword);
        }

    }
}
