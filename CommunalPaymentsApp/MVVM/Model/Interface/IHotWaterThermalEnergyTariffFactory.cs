using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.Interface
{
    public interface IHotWaterThermalEnergyTariffFactory
    {
        public AbstractServiceParameter.ServiceParameter CreateHotWaterThermalEnergyParameter(double volumeOfHotWater);
    }
}
