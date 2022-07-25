using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using CommunalPaymentsApp.MVVM.Model.Interface;
namespace CommunalPaymentsApp.MVVM.Model.Factory
{
    public class HotWaterParameterFactory : IServiceFactory
    {
        public NormativeServiceParameter CreateNormativeServiceParameter(int numberOfResidents)
        {
            return new HotWaterNormativeParameter(numberOfResidents);
        }

        public TariffServiceParameter CreateGeneralTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new HotWaterGeneralTariffParameter(serviceCost, previousSevriceCost);
        }
    }
}
