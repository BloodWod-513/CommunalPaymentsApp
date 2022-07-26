using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public double Electrocity { get; set; }
        public double PrevElectrocity { get; set; }
        public double ElectrocityPerDay { get; set; }
        public double PrevElectrocityPerDay { get; set; }
        public double ElectrocityPerNight { get; set; }
        public double PrevElectrocityPerNight { get; set; }
        public bool ElectricyTwoTariffCheckBoxIsChecked { get; set; }
    }
}
