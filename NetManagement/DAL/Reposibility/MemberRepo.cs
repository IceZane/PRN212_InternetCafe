using DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
        public void Delete(Member member) // Đổi tham số từ Computer -> Member
        {
            _account = new();

            // 1. QUAN TRỌNG: Kiểm tra xem thành viên này có đang dùng máy không
            // Nếu xóa, database sẽ báo lỗi Foreign Key vì bảng Computer đang tham chiếu đến
            bool isUsingComputer = _account.Computers.Any(c => c.UsedByMember == member.MemberId);

            if (isUsingComputer)
            {
                // Ném ra lỗi để Service và UI (ở bước 1) bắt được
                throw new InvalidOperationException("This member is currently using a computer. You must log them off first before deleting.");
            }

            // 2. Nếu không dùng máy, tiến hành xóa
            // Vì 'member' là một đối tượng từ bên ngoài context,
            // chúng ta cần 'Attach' nó vào context trước khi 'Remove'.
            try
            {
                _account.Members.Attach(member);
                _account.Members.Remove(member);
                _account.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Xử lý các lỗi database khác nếu có
                throw new Exception("Database error while deleting. See inner exception.", ex);
            }
        }
    }
}
