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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunalPaymentsApp.MVVM.Model;
using CommunalPaymentsApp.MVVM.Model.Factory;
using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;

namespace CommunalPaymentsApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM = new MainWindowViewModel();
            DataContext = MainWindowVM;
        }

        private void MakeAccrualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TryEnterAmountOfResidents(AmountOfResidents.TextBox.Text))
                return;
            int numberOfResidents = int.Parse(AmountOfResidents.TextBox.Text);

            ServiceParameter? coldWaterServiceParameter = null,
                hotWaterServiceParameter = null,
                electricyServiceParameter = null, electricyPerDayServiceParameter = null, electricyPerNightServiceParameter = null;
            if ((bool)ColdWater.CheckBox.IsChecked)
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateGeneralTariffParameter(new ColdWaterParameterFactory(), ColdWater.Value, 0);
            }
            else
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ColdWaterParameterFactory(), numberOfResidents);
            }
            if ((bool)HotWater.CheckBox.IsChecked)
            {
                hotWaterServiceParameter = ServiceParameterCreator.CreateGeneralTariffParameter(new HotWaterParameterFactory(), HotWater.Value, 0);
            }
            else
            {
                hotWaterServiceParameter = ServiceParameterCreator.CreateNormativParameter(new HotWaterParameterFactory(), numberOfResidents);
            }

            if ((bool)ElectricyCheckBox.IsChecked)
            {
                if (MainWindowVM.ElectricyTwoTariffCheckBoxIsChecked)
                {
                    electricyServiceParameter = ServiceParameterCreator.CreateGeneralTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay + MainWindowVM.ElectrocityPerNight, 0);
                    electricyPerDayServiceParameter = ServiceParameterCreator.CreateDayTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay, 0);
                    electricyPerNightServiceParameter = ServiceParameterCreator.CreateNightTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerNight, 0);
                    electricyServiceParameter.Tariff.Normative = electricyPerDayServiceParameter?.Tariff?.Normative + electricyPerNightServiceParameter?.Tariff?.Normative;
                    electricyServiceParameter.Tariff.Cost = 0;
                    electricyServiceParameter.AutoResult = false;
                    electricyServiceParameter.Result = electricyPerDayServiceParameter.Result + electricyPerNightServiceParameter.Result;
                }
                else
                    electricyServiceParameter = ServiceParameterCreator.CreateGeneralTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.Electrocity, 0);
            }
            else
            {
                electricyServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ElectrocityParameterFactory(), numberOfResidents);
            }
            List<ServiceParameter?> serviceParameters = new() { coldWaterServiceParameter, hotWaterServiceParameter, electricyServiceParameter, electricyPerDayServiceParameter, electricyPerNightServiceParameter };
            serviceParameters.RemoveAll(p => p == null);
            ResultWindow resultWindow = new(serviceParameters);
            resultWindow.ShowDialog();
        }
        private bool TryEnterAmountOfResidents(string amountOfResidents)
        {
            if (string.IsNullOrWhiteSpace(amountOfResidents))
            {
                ShowError("Вы ничего не ввели.");
                return false;
            }
            else if (!int.TryParse(amountOfResidents, out int number))
            {
                ShowError("Введите число.");
                return false;
            }
            return true;
        }
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
