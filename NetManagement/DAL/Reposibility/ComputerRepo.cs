using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposibility
{
    public class ComputerRepo
    {
        private NetManagementDbContext _computer;
        private NetManagementDbContext _account;

        public List<Computer> GetAllComputer()
        {
            _computer = new();
            return _computer.Computers.ToList();
        }
        public void Delete(Computer obj)
        {
            _computer = new();  
            _computer.Computers.Remove(obj); 
            _computer.SaveChanges(); 
        }

        public List<string> GetDistinctStatuses()
        {
            _computer = new();
            return _computer.Computers.Select(c => c.Status).Distinct().ToList();
        }

        public List<Computer> Search(string keyword, string status)
        {
            _computer = new();
            var query = _computer.Computers.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.ComputerName.ToLower().Contains(keyword.ToLower()));
            }

            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                query = query.Where(c => c.Status == status);
            }

            return query.ToList();
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
