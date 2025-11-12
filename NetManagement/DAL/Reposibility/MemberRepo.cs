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
        public List<Member> Create(Member member)
        {
            _account = new();

            // Gán mặc định nếu chưa có
            member.DateCreated ??= DateTime.Now;
            member.Status ??= "Active";

            _account.Members.Add(member);
            _account.SaveChanges();

            return _account.Members.ToList();
        }
        public List<Member> Update(Member member)
        {
            _account = new();
            var existingMember = _account.Members.Find(member.MemberId);
            if (existingMember != null)
            {
                existingMember.AccountName = member.AccountName;
                existingMember.Password = member.Password;
                existingMember.FullName = member.FullName;
                existingMember.Phone = member.Phone;
                existingMember.CitizenId = member.CitizenId;
                existingMember.Money = member.Money;
                existingMember.DateCreated = member.DateCreated;
                existingMember.Status = member.Status;
                _account.SaveChanges();
            }
            return _account.Members.ToList();
        }
    }
}
