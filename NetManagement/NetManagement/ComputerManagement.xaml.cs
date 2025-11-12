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
    /// Interaction logic for ComputerManagement.xaml
    /// </summary>
    public partial class ComputerManagement : Window
    {
        public ComputerManagement()
        {
            InitializeComponent();
        }
        private ComputerService _computerservice = new();

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void FillDataGrid(List<Computer> bag)
        {
            ComputerDataGrid.ItemsSource = null;
            ComputerDataGrid.ItemsSource = bag;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load all computers initially
            FillDataGrid(_computerservice.GetAllComputer());

            // Populate the status combo box
            var statuses = _computerservice.GetDistinctStatuses();
            statuses.Insert(0, "All"); // Add "All" option
            StatusComboBox.ItemsSource = statuses;
            StatusComboBox.SelectedIndex = 0; // Select "All" by default
        }

        private void SearchComputer_Click(object sender, RoutedEventArgs e)
        {
            var keyword = SearchListComputer.Text;
            var status = StatusComboBox.SelectedItem as string;

            FillDataGrid(_computerservice.Search(keyword, status));
        }
    }
}
