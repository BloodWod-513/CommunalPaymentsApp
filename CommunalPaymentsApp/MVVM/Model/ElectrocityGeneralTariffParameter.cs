using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class ElectrocityGeneralTariffParameter : AbstractServiceParameter.TariffServiceParameter
    {
        public ElectrocityGeneralTariffParameter(double serviceCost, double previousSevriceCost) : base(serviceCost, previousSevriceCost)
        {
            Tariff = CloneTariff(Tariff.TypeTariff.Electricity);
        }
    }
}
