using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class ColdWaterNormativeParameter : NormativeServiceParameter
    {
        public ColdWaterNormativeParameter(int numberOfResidents) : base(numberOfResidents, Tariff.TypeTariff.ColdWater)
        {
            Tariff = CloneTariff(Tariff.TypeTariff.ColdWater);
        }
    }
}
