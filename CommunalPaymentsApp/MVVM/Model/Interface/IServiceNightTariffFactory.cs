using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.Interface
{
    public interface IServiceNightTariffFactory
    {
        TariffServiceParameter CreateNightTariffServiceParameter(double serviceCost, double previousSevriceCost);
    }
}
