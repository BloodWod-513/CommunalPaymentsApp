using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    internal class HotWaterOfHeatCarrierTariffParameter : AbstractServiceParameter.TariffServiceParameter
    {
        public HotWaterOfHeatCarrierTariffParameter(double serviceCost, double previousSevriceCost) : base(serviceCost, previousSevriceCost, Tariff.TypeTariff.HotWaterOfHeatCarrier)
        {

        }
    }
}
