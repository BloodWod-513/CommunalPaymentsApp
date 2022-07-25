using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class HotWaterNormativeParameter : AbstractServiceParameter.NormativeServiceParameter
    {
        public HotWaterNormativeParameter(int numberOfResidents) : base(numberOfResidents, Tariff.TypeTariff.HotWater)
        {
            Tariff = CloneTariff(Tariff.TypeTariff.HotWater);
        }
    }
}
