using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter
{
    public abstract class NormativeServiceParameter : ServiceParameter
    {
        public int NumberOfResidents { get; set; }
        public NormativeServiceParameter(int numberOfResidents, Tariff.TypeTariff typeTariff) 
            : base(typeTariff)
        {
            double cost = 0;
            if (Tariff?.Normative != null)
                cost = (double)Tariff.Normative;
            NumberOfResidents = numberOfResidents;
            VolumeOfService = numberOfResidents * cost;
        }
    }
}
