<<<<<<< HEAD
﻿using BLL.Service;
using DAL.Entities;
using System.Text;
=======
﻿using System.Text;
>>>>>>> 239f428882aad7dfed972506174d8ec2d52f7e91
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
<<<<<<< HEAD
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
    }

        }

        
=======
    }
}
>>>>>>> 239f428882aad7dfed972506174d8ec2d52f7e91
