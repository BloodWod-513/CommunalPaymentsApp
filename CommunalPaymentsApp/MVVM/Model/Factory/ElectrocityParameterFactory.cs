using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using CommunalPaymentsApp.MVVM.Model.Interface;

namespace CommunalPaymentsApp.MVVM.Model.Factory
{
    public class ElectrocityParameterFactory : IServiceFactory, IServiceDayTariffFactory, IServiceNightTariffFactory
    {
        public NormativeServiceParameter CreateNormativeServiceParameter(int numberOfResidents)
        {
            return new ElectrocityNormativeParameter(numberOfResidents);
        }

        public TariffServiceParameter CreateTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new ElectrocityTariffParameter(serviceCost, previousSevriceCost);
        }

        public TariffServiceParameter CreateDayTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new ElectrocityPerDayTariffParameter(serviceCost, previousSevriceCost);
        }

        public TariffServiceParameter CreateNightTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new ElectrocityPerNightTariffParameter(serviceCost, previousSevriceCost);
        }
    }
}
