using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class ElectrocityTariffParameter : AbstractServiceParameter.TariffServiceParameter
    {
        public ElectrocityTariffParameter(double serviceCost, double previousSevriceCost) : base(serviceCost, previousSevriceCost, Tariff.TypeTariff.Electricity)
        {
        }
    }
}
