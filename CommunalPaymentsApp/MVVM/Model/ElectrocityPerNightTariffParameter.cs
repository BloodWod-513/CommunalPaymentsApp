using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    internal class ElectrocityPerNightTariffParameter : AbstractServiceParameter.TariffServiceParameter
    {
        public ElectrocityPerNightTariffParameter(double serviceCost, double previousSevriceCost) : base(serviceCost, previousSevriceCost)
        {
            Tariff = CloneTariff(Tariff.TypeTariff.ElectricityPerNight);
        }
    }
}
