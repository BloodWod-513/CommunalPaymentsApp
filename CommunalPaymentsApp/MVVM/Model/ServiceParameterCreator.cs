using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public static class ServiceParameterCreator
    {
        public static ServiceParameter CreateNormativParameter(Interface.IServiceFactory serviceFactory, int numberOfResidents)
        {
            return serviceFactory.CreateNormativeServiceParameter(numberOfResidents);
        }
        public static ServiceParameter CreateTariffParameter(Interface.IServiceFactory serviceFactory, double serviceCost, double previousServiceCost)
        {
            return serviceFactory.CreateTariffServiceParameter(serviceCost, previousServiceCost);
        }
        public static ServiceParameter CreateDayTariffParameter(Interface.IServiceDayTariffFactory serviceFactory, double serviceCost, double previousServiceCost)
        {
            return serviceFactory.CreateDayTariffServiceParameter(serviceCost, previousServiceCost);
        }
        public static ServiceParameter CreateNightTariffParameter(Interface.IServiceNightTariffFactory serviceFactory, double serviceCost, double previousServiceCost)
        {
            return serviceFactory.CreateNightTariffServiceParameter(serviceCost, previousServiceCost);
        }
        public static ServiceParameter CreateHotWaterThermalEnergyParameter(Interface.IHotWaterThermalEnergyTariffFactory hotWaterThermalEnergyTariffFactory, double volumeOfHotWater)
        {
            return hotWaterThermalEnergyTariffFactory.CreateHotWaterThermalEnergyParameter(volumeOfHotWater);
        }
    }
}
