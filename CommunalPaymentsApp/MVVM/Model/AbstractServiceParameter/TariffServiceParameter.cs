using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter
{
    public abstract class TariffServiceParameter : ServiceParameter
    {
        public double PreviousSevriceCost { get; set; }
        public TariffServiceParameter(double serviceCost, double previousSevriceCost) : base(serviceCost)
        {
            VolumeOfService = serviceCost - previousSevriceCost;
        }
    }
}
