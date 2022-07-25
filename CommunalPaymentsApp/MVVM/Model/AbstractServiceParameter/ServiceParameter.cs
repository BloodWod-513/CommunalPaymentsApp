using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter
{
    public abstract class ServiceParameter
    {
        public Tariff? Tariff { get; set; }
        public double ServiceCost { get; set; }
        public double VolumeOfService { get; set; }
        public bool AutoResult { get; set; } = true;
        public double? Result
        {
            get
            {
                if (AutoResult)
                    _result = VolumeOfService * Tariff?.Cost;
                return _result;
            }
            set
            {
                if (!AutoResult)
                    _result = value;
            }
        }
        private double? _result;
        public ServiceParameter(double serviceCost)
        {
            ServiceCost = serviceCost;
        }
        protected Tariff CloneTariff(Tariff.TypeTariff typeTariff)
        {
            Tariff? tariff = App.tariffs.FirstOrDefault(t => t.TypeTariffId == typeTariff);
            return (Tariff)tariff.Clone();
        }
    }
}
