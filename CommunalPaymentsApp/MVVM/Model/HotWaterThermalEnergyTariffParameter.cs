using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class HotWaterThermalEnergyTariffParameter : AbstractServiceParameter.ServiceParameter
    {
        public HotWaterThermalEnergyTariffParameter(double volumeOfHotWater) : base(Tariff.TypeTariff.HotWaterThermalEnergy)
        {
            if (Tariff?.Normative != null)
                VolumeOfService = (double)(volumeOfHotWater * Tariff.Normative);
        }
    }
}
