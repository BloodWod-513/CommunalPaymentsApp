using CommunalPaymentsApp.MVVM.Model;
using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using CommunalPaymentsApp.MVVM.ViewModel;
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

namespace CommunalPaymentsApp.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ReusltWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindowViewModel ResultWindowViewModel { get; set; }
        private ResultWindow()
        {
            InitializeComponent();
        }
        public ResultWindow(List<ServiceParameter> serviceParameters, int numberOfResidents, double debt) : this()
        {
            ResultWindowViewModel = new(serviceParameters, numberOfResidents, debt);
            DataContext = ResultWindowViewModel;
            DataGridResult.ItemsSource = ResultWindowViewModel.ServiceParameters;
        }
        private void GoToNextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)this.Owner;
            mainWindow.Debt.TextBox.Text = ResultWindowViewModel.TotalAmountResult.ToString();
            this.Close();
        }
    }
}
