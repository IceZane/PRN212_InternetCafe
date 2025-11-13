using BLL.Service;
using DAL.Entities;
using DAL.Reposibility;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private MemberService _accountservice = new();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)

                {

                    FillDataGrid(_accountservice.GetAllAccount());

                }

        

                private void FillDataGrid(List<Member> bag)

                {

                    AccountDataGrid.ItemsSource = null;

                    AccountDataGrid.ItemsSource = bag;


                }


               



        private void SearchButton_Click(object sender, RoutedEventArgs e)

                {

                    var keyword = SearchListAccount.Text;

                    if (string.IsNullOrEmpty(keyword))

                    {

                        FillDataGrid(_accountservice.GetAllAccount());

                    }

                    else

                    {

                        FillDataGrid(_accountservice.Search(keyword));

                    }

                }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. Lấy đúng đối tượng 'Member' từ DataGrid
            Member? selected = AccountDataGrid.SelectedItem as Member;

            if (selected == null)
            {
                // 2. Sửa lại thông báo lỗi
                MessageBox.Show("Please select a member before deleting", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            // 3. Sửa lại nội dung hộp thoại xác nhận
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete this member?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            try
            {
                // 4. Gọi service 'DeleteMember' (chúng ta sẽ sửa hàm này ở bước 2)
                _accountservice.DeleteMember(selected);

                // 5. Refresh lại grid bằng danh sách Member
                MessageBox.Show("Delete successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                FillDataGrid(_accountservice.GetAllAccount());
            }
            catch (InvalidOperationException ex)
            {
                // Bắt lỗi nếu thành viên đang sử dụng máy (sẽ làm ở bước 3)
                MessageBox.Show(ex.Message, "Deletion Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi chung khác (ví dụ: lỗi database)
                MessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow(null, _accountservice);
            bool? result = detailWindow.ShowDialog();

            if (result == true)
            {
                FillDataGrid(_accountservice.GetAllAccount());
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ DataGrid
            var selectedMember = AccountDataGrid.SelectedItem as Member;

            if (selectedMember == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để cập nhật.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mở DetailWindow với dữ liệu đã chọn
            DetailWindow detailWindow = new DetailWindow(selectedMember, _accountservice); 
            bool? result = detailWindow.ShowDialog();

            if (result == true)
            {
                // Sau khi cập nhật, làm mới lại danh sách
                FillDataGrid(_accountservice.GetAllAccount());
            }
        }
    }

        }

        