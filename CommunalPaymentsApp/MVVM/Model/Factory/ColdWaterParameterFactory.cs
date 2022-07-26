using CommunalPaymentsApp.MVVM.Model.Interface;
using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.Factory
{
    public class ColdWaterParameterFactory : IServiceFactory
    {
        public NormativeServiceParameter CreateNormativeServiceParameter(int numberOfResidents)
        {
            return new ColdWaterNormativeParameter(numberOfResidents);
        }

        public TariffServiceParameter CreateTariffServiceParameter(double serviceCost, double previousSevriceCost)
        {
            return new ColdWaterTariffParameter(serviceCost, previousSevriceCost);
        }
    }
}
