using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class ElectrocityNormativeParameter : AbstractServiceParameter.NormativeServiceParameter
    {
        public ElectrocityNormativeParameter(int numberOfResidents) : base(numberOfResidents, Tariff.TypeTariff.Electricity)
        {
        }
    }
}
