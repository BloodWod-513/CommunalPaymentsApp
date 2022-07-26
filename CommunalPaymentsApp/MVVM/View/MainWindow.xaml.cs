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
            if (!TryEnterNumber(AmountOfResidents.TextBox.Text))
                return;
            int numberOfResidents = int.Parse(AmountOfResidents.TextBox.Text);
            if (!TryEnterNumber(Debt.TextBox.Text))
                return;
            double debt = double.Parse(Debt.TextBox.Text);

            ServiceParameter? coldWaterServiceParameter = null,
                hotWaterOfHeatCarrieServiceParameter = null, hotWaterThermalEnergy = null,
                electricyServiceParameter = null, electricyPerDayServiceParameter = null, electricyPerNightServiceParameter = null;
            if ((bool)ColdWater.CheckBox.IsChecked)
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ColdWaterParameterFactory(), ColdWater.Value, ColdWater.PrevValue);
            }
            else
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ColdWaterParameterFactory(), numberOfResidents);
            }
            if ((bool)HotWater.CheckBox.IsChecked)
            {
                hotWaterOfHeatCarrieServiceParameter = ServiceParameterCreator.CreateTariffParameter(new HotWaterParameterFactory(), HotWater.Value, HotWater.PrevValue);
            }
            else
            {
                hotWaterOfHeatCarrieServiceParameter = ServiceParameterCreator.CreateNormativParameter(new HotWaterParameterFactory(), numberOfResidents);
            }
            hotWaterThermalEnergy = ServiceParameterCreator.CreateHotWaterThermalEnergyParameter(new HotWaterParameterFactory(), hotWaterOfHeatCarrieServiceParameter.VolumeOfService);

            if ((bool)ElectricyCheckBox.IsChecked)
            {
                if (MainWindowVM.ElectricyTwoTariffCheckBoxIsChecked)
                {
                    electricyPerDayServiceParameter = ServiceParameterCreator.CreateDayTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay, MainWindowVM.PrevElectrocityPerDay);
                    electricyPerNightServiceParameter = ServiceParameterCreator.CreateNightTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerNight, MainWindowVM.PrevElectrocityPerNight);

                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay + MainWindowVM.ElectrocityPerNight, 0);
                    electricyServiceParameter.Tariff.Normative = electricyPerDayServiceParameter?.Tariff?.Normative + electricyPerNightServiceParameter?.Tariff?.Normative;
                    electricyServiceParameter.Tariff.Cost = 0;
                    electricyServiceParameter.AutoResult = false;
                    electricyServiceParameter.Result = electricyPerDayServiceParameter.Result + electricyPerNightServiceParameter.Result;
                }
                else
                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.Electrocity, MainWindowVM.PrevElectrocity);
            }
            else
            {
                electricyServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ElectrocityParameterFactory(), numberOfResidents);
            }
            List<ServiceParameter> serviceParameters = new() { coldWaterServiceParameter, hotWaterOfHeatCarrieServiceParameter, hotWaterThermalEnergy, electricyServiceParameter, electricyPerDayServiceParameter, electricyPerNightServiceParameter };
            serviceParameters.RemoveAll(p => p == null);
            ResultWindow resultWindow = new(serviceParameters, numberOfResidents, debt);
            resultWindow.ShowDialog();
        }
        private bool TryEnterNumber(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                ShowError("Вы ничего не ввели.");
                return false;
            }
            else if (!int.TryParse(str, out int number))
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
