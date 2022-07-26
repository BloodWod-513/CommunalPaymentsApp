using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.Interface
{
    public interface IServiceTariffFactory
    {
        TariffServiceParameter CreateTariffServiceParameter(double serviceCost, double previousSevriceCost);
    }
}
