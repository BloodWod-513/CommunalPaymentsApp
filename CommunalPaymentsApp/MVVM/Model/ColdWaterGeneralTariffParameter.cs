using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class ColdWaterGeneralTariffParameter : TariffServiceParameter
    {
        public ColdWaterGeneralTariffParameter(double serviceCost, double previousSevriceCost) : base(serviceCost, previousSevriceCost)
        {
            Tariff = CloneTariff(Tariff.TypeTariff.ColdWater);
        }
    }
}
