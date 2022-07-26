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
            Debt.TextBox.Text = "0";
            Payment.TextBox.Text = "0";
        }
        private void MakeAccrualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TryEnterInt(AmountOfResidents.TextBox.Text))
                return;
            int numberOfResidents = int.Parse(AmountOfResidents.TextBox.Text);

            if (!TryEnterDouble(Debt.TextBox.Text))
                return;
            double debt = double.Parse(Debt.TextBox.Text); 

            if (!TryEnterDouble(Payment.TextBox.Text))
                return;
            double payment = double.Parse(Payment.TextBox.Text);
            debt -= payment;

            bool isCorrectParams = true;

            ServiceParameter? coldWaterServiceParameter = null,
                hotWaterOfHeatCarrieServiceParameter = null, hotWaterThermalEnergy = null,
                electricyServiceParameter = null, electricyPerDayServiceParameter = null, electricyPerNightServiceParameter = null;
            if ((bool)ColdWater.CheckBox.IsChecked)
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ColdWaterParameterFactory(), ColdWater.Value, ColdWater.PrevValue);
                isCorrectParams = CurMoreThanPrevParameter(ColdWater.PrevValue, ColdWater.Value);
                if (!isCorrectParams) return;
            }
            else
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ColdWaterParameterFactory(), numberOfResidents);
            }
            if ((bool)HotWater.CheckBox.IsChecked)
            {
                hotWaterOfHeatCarrieServiceParameter = ServiceParameterCreator.CreateTariffParameter(new HotWaterParameterFactory(), HotWater.Value, HotWater.PrevValue);
                isCorrectParams = CurMoreThanPrevParameter(HotWater.PrevValue, HotWater.Value);
                if (!isCorrectParams) return;
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
                    isCorrectParams = CurMoreThanPrevParameter(MainWindowVM.PrevElectrocityPerDay, MainWindowVM.ElectrocityPerDay);
                    if (!isCorrectParams) return;

                    electricyPerNightServiceParameter = ServiceParameterCreator.CreateNightTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerNight, MainWindowVM.PrevElectrocityPerNight);          
                    isCorrectParams = CurMoreThanPrevParameter(MainWindowVM.PrevElectrocityPerNight, MainWindowVM.ElectrocityPerNight);
                    if (!isCorrectParams) return;

                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay + MainWindowVM.ElectrocityPerNight,
                        MainWindowVM.PrevElectrocityPerDay + MainWindowVM.PrevElectrocityPerNight);
                    electricyServiceParameter.Tariff.Normative = electricyPerDayServiceParameter?.Tariff?.Normative + electricyPerNightServiceParameter?.Tariff?.Normative;
                    electricyServiceParameter.Tariff.Cost = 0;
                    electricyServiceParameter.AutoResult = false;
                    electricyServiceParameter.Result = electricyPerDayServiceParameter.Result + electricyPerNightServiceParameter.Result;
                }
                else
                {
                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.Electrocity, MainWindowVM.PrevElectrocity);
                    isCorrectParams = CurMoreThanPrevParameter(MainWindowVM.PrevElectrocity, MainWindowVM.Electrocity);
                    if (!isCorrectParams) return;
                }
            }
            else
            {
                electricyServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ElectrocityParameterFactory(), numberOfResidents);
            }
            List<ServiceParameter> serviceParameters = new() { coldWaterServiceParameter, hotWaterOfHeatCarrieServiceParameter, hotWaterThermalEnergy, electricyServiceParameter, electricyPerDayServiceParameter, electricyPerNightServiceParameter };
            serviceParameters.RemoveAll(p => p == null);
            ResultWindow resultWindow = new(serviceParameters, numberOfResidents, debt);
            resultWindow.Owner = this;
            resultWindow.ShowDialog();
        }
        private bool CurMoreThanPrevParameter(double prevValue, double value)
        {
            if (prevValue > value)
            {
                ShowError("Текущий параметр не может быть меньше предыдущего.");
                return false;
            }
            return true;
        }
        private bool TryEnterInt(string str)
        {
            if (!CheckString(str))
                return false;
            else if (!int.TryParse(str, out int number))
            {
                ShowError("Введите целочисленное число.");
                return false;
            }
            return true;
        }
        private bool TryEnterDouble(string str)
        {
            if (!CheckString(str))
                return false;
            else if (!double.TryParse(str, out double number))
            {
                ShowError("Введите нецелочисленное число.");
                return false;
            }
            return true;
        }
        private bool CheckString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                ShowError("Вы ничего не ввели.");
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
