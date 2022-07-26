using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class HotWaterOfHeatCarrierNormativeParameter : AbstractServiceParameter.NormativeServiceParameter
    {
        public HotWaterOfHeatCarrierNormativeParameter(int numberOfResidents) : base(numberOfResidents, Tariff.TypeTariff.HotWaterOfHeatCarrier)
        {
        }
    }
}
