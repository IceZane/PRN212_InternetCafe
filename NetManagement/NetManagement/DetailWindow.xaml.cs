using BLL.Service;
using DAL.Entities;
using System;
using System.Windows;

namespace NetManagement
{
    public partial class DetailWindow : Window
    {
        private Member _member;
        private readonly MemberService _memService;

        public DetailWindow(Member? member, MemberService service)
        {
            InitializeComponent();

            _memService = service;
            _member = member ?? new Member
            {
                DateCreated = DateTime.Now,
                Status = "Active"
            };

            LoadMemberData();
        }

        private void LoadMemberData()
        {
            // Chỉ hiển thị MemberId nếu đang cập nhật
            txtMemberId.Text = _member.MemberId > 0 ? _member.MemberId.ToString() : "";

            txtAccountName.Text = _member.AccountName;
            txtPassword.Password = _member.Password;
            txtFullName.Text = _member.FullName;
            txtPhone.Text = _member.Phone;
            txtCitizenId.Text = _member.CitizenId;
            txtMoney.Text = _member.Money?.ToString("F2");
            txtDateCreated.Text = _member.DateCreated?.ToString("g");
            txtStatus.Text = _member.Status;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_member.MemberId <= 0)
            {
                // Tạo mới: KHÔNG dùng _member, tạo đối tượng mới
                var newMember = new Member
                {
                    AccountName = txtAccountName.Text.Trim(),
                    Password = txtPassword.Password.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    CitizenId = txtCitizenId.Text.Trim(),
                    Money = decimal.TryParse(txtMoney.Text, out var money) ? money : null,
                    DateCreated = DateTime.Now,
                    Status = "Active"
                };

                _memService.Create(newMember);
                MessageBox.Show("Thêm thành viên mới thành công!");
            }
            else
            {
                // Cập nhật: dùng _member
                _member.AccountName = txtAccountName.Text.Trim();
                _member.Password = txtPassword.Password.Trim();
                _member.FullName = txtFullName.Text.Trim();
                _member.Phone = txtPhone.Text.Trim();
                _member.CitizenId = txtCitizenId.Text.Trim();
                _member.Money = decimal.TryParse(txtMoney.Text, out var money) ? money : null;
                _member.DateCreated = _member.DateCreated ?? DateTime.Now;
                _member.Status = _member.Status ?? "Active";

                _memService.Update(_member);
                MessageBox.Show("Cập nhật thành công!");
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public Member GetMember() => _member;
    }
}