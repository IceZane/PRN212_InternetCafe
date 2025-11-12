using BLL.Service;
using DAL.Entities;
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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
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
            DetailWindow detailWindow = new DetailWindow(selectedMember);
            bool? result = detailWindow.ShowDialog();

            if (result == true)
            {
                // Sau khi cập nhật, làm mới lại danh sách
                FillDataGrid(_accountservice.GetAllAccount());
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

        