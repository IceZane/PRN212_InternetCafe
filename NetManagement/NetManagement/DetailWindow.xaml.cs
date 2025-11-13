using BLL.Service;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetManagement
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private Member _member;
        public MemberService _memService = new MemberService();


        public DetailWindow(Member? member = null)
        {
            InitializeComponent();

            if (member == null)
            {
                _member = new Member
                {
                    DateCreated = DateTime.Now,
                    Status = "Active"
                };
            }
            else
            {
                _member = member;
            }

            LoadMemberData();
        }

        private void LoadMemberData()
        {
            txtMemberId.Text = _member.MemberId.ToString();
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
            _member.AccountName = txtAccountName.Text;
            _member.Password = txtPassword.Password;
            _member.FullName = txtFullName.Text;
            _member.Phone = txtPhone.Text;
            _member.CitizenId = txtCitizenId.Text;
            _member.Money = decimal.TryParse(txtMoney.Text, out var money) ? money : null;

            if (_member.MemberId == 0)
            {
                // Tạo mới
                _member.DateCreated = DateTime.Now;
                _member.Status = "Active";
                _memService.Create(_member);
            }
            else
            {
                // Cập nhật
                _memService.Update(_member);
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
