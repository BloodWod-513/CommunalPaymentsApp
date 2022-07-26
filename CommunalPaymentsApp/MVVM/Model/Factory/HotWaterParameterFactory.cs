using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using CommunalPaymentsApp.MVVM.Model.Interface;
namespace CommunalPaymentsApp.MVVM.Model.Factory
{
    public class HotWaterParameterFactory : IServiceFactory, IHotWaterThermalEnergyTariffFactory
    {
        public ServiceParameter CreateHotWaterThermalEnergyParameter(double volumeOfHotWater)
        {
            return new HotWaterThermalEnergyTariffParameter(volumeOfHotWater);
        }

        public NormativeServiceParameter CreateNormativeServiceParameter(int numberOfResidents)
        {
            return new HotWaterOfHeatCarrierNormativeParameter(numberOfResidents);
        }

        public TariffServiceParameter CreateTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new HotWaterOfHeatCarrierTariffParameter(serviceCost, previousSevriceCost);
        }
    }
}
