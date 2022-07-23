using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    internal class Tariff
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Cost { get; set; }
        public double? Standart { get; set; }
        public string UnitMesurement => _unitMesurement;
        private string _unitMesurement;
        public Tariff(string serviceName, double cost, double? standart, UnitsMesurement unitMesurement)
        {
            ServiceName = serviceName;
            Cost = cost;
            Standart = standart;
            SetUnitMesurement(unitMesurement);
        }

        public void SetUnitMesurement(UnitsMesurement unitMesurement)
        {
            switch (unitMesurement)
            {
                case UnitsMesurement.Kilowatt:
                    _unitMesurement = "кВт.ч";
                    break;
                case UnitsMesurement.CubicMeter:
                    _unitMesurement = "м^3";
                    break;
                case UnitsMesurement.Gigacalories:
                    _unitMesurement = "Гкал";
                    break;
            }
        }
        public enum UnitsMesurement
        {
            Kilowatt = 0,
            CubicMeter,
            Gigacalories
        }
    }
}
