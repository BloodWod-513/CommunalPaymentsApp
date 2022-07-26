using CommunalPaymentsApp.MVVM.ViewModel;
using System.Collections.Generic;
using System.Windows;

using CommunalPaymentsApp.MVVM.Model;
using CommunalPaymentsApp.MVVM.Model.Factory;
using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using CommunalPaymentsApp.ValidationTools;

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
            if (!DigitValidation.TryEnterInt(AmountOfResidents.TextBox.Text, "Число жильцов"))
                return;
            int numberOfResidents = int.Parse(AmountOfResidents.TextBox.Text);

            if (!DigitValidation.TryEnterDouble(Debt.TextBox.Text, "Долг"))
                return;
            double debt = double.Parse(Debt.TextBox.Text); 

            if (!DigitValidation.TryEnterDouble(Payment.TextBox.Text, "Плата"))
                return;
            double payment = double.Parse(Payment.TextBox.Text);
            debt -= payment;

            bool isCorrectParams = true;

            ServiceParameter? coldWaterServiceParameter = null,
                hotWaterOfHeatCarrieServiceParameter = null, hotWaterThermalEnergy = null,
                electricyServiceParameter = null, electricyPerDayServiceParameter = null, electricyPerNightServiceParameter = null;
            if ((bool)ColdWater.CheckBox.IsChecked)
            {
                if (!DigitValidation.TryEnterDouble(ColdWater.Value.ToString(), "Холодная вода текущий") || !DigitValidation.TryEnterDouble(ColdWater.PrevValue.ToString(), "Холодная вода предыдущий"))
                    return;
                isCorrectParams = DigitValidation.CurMoreThanPrevParameter(ColdWater.PrevValue, ColdWater.Value);
                if (!isCorrectParams) return;
                coldWaterServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ColdWaterParameterFactory(), ColdWater.Value, ColdWater.PrevValue);
            }
            else
            {
                coldWaterServiceParameter = ServiceParameterCreator.CreateNormativParameter(new ColdWaterParameterFactory(), numberOfResidents);
            }
            if ((bool)HotWater.CheckBox.IsChecked)
            {
                if (!DigitValidation.TryEnterDouble(HotWater.Value.ToString(), "Горячая вода текущий") || !DigitValidation.TryEnterDouble(HotWater.PrevValue.ToString(), "Горячая вода предыдущий"))
                    return;
                isCorrectParams = DigitValidation.CurMoreThanPrevParameter(HotWater.PrevValue, HotWater.Value);
                if (!isCorrectParams) return;
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
                    if (!DigitValidation.TryEnterDouble(MainWindowVM.PrevElectrocityPerDay.ToString(), "Электричество за день предыдущий")
                        || !DigitValidation.TryEnterDouble(MainWindowVM.ElectrocityPerDay.ToString(), "Электричество за день текущий"))
                        return;
                    isCorrectParams = DigitValidation.CurMoreThanPrevParameter(MainWindowVM.PrevElectrocityPerDay, MainWindowVM.ElectrocityPerDay);
                    if (!isCorrectParams) return;
                    electricyPerDayServiceParameter = ServiceParameterCreator.CreateDayTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay, MainWindowVM.PrevElectrocityPerDay);

                    if (!DigitValidation.TryEnterDouble(MainWindowVM.PrevElectrocityPerNight.ToString(), "Электричество за ночь предыдущий") 
                        || !DigitValidation.TryEnterDouble(MainWindowVM.ElectrocityPerNight.ToString(), "Электричество за день текущий"))
                        return;
                    isCorrectParams = DigitValidation.CurMoreThanPrevParameter(MainWindowVM.PrevElectrocityPerNight, MainWindowVM.ElectrocityPerNight);
                    if (!isCorrectParams) return;
                    electricyPerNightServiceParameter = ServiceParameterCreator.CreateNightTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerNight, MainWindowVM.PrevElectrocityPerNight);          

                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.ElectrocityPerDay + MainWindowVM.ElectrocityPerNight,
                        MainWindowVM.PrevElectrocityPerDay + MainWindowVM.PrevElectrocityPerNight);
                    electricyServiceParameter.Tariff.Normative = electricyPerDayServiceParameter?.Tariff?.Normative + electricyPerNightServiceParameter?.Tariff?.Normative;
                    electricyServiceParameter.Tariff.Cost = 0;
                    electricyServiceParameter.AutoResult = false;
                    electricyServiceParameter.Result = electricyPerDayServiceParameter.Result + electricyPerNightServiceParameter.Result;
                }
                else
                {
                    if (!DigitValidation.TryEnterDouble(MainWindowVM.Electrocity.ToString(), "Электричество текущий") 
                        || !DigitValidation.TryEnterDouble(MainWindowVM.PrevElectrocity.ToString(), "Электричество предыдущий"))
                        return;
                    electricyServiceParameter = ServiceParameterCreator.CreateTariffParameter(new ElectrocityParameterFactory(), MainWindowVM.Electrocity, MainWindowVM.PrevElectrocity);
                    isCorrectParams = DigitValidation.CurMoreThanPrevParameter(MainWindowVM.PrevElectrocity, MainWindowVM.Electrocity);
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
    }
}
