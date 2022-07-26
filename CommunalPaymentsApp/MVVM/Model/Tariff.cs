﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.Model
{
    public class Tariff : ICloneable
    {
        public int? Id { get; set; }
        public string ServiceName { get; set; } = "";
        public double Cost { get; set; }
        public double? Normative { get; set; }
        public TypeTariff TypeTariffId { get; set; }
        public string UnitMesurement
        {
            get => _unitMesurement;
            private set
            {
                _unitMesurement = value;
            }
        }
        private string _unitMesurement = "";
        private Tariff() { }
        public Tariff(string serviceName, double cost, double? standart, UnitsMesurement unitMesurement, TypeTariff typeTariffId)
        {
            ServiceName = serviceName;
            Cost = cost;
            Normative = standart;
            SetUnitMesurement(unitMesurement);
            TypeTariffId = typeTariffId;
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

        public object Clone()
        {
            return MemberwiseClone();
        }

        public enum UnitsMesurement
        {
            Kilowatt = 0,
            CubicMeter,
            Gigacalories
        }
        public enum TypeTariff
        {
            ColdWater = 0,
            HotWater,
            Electricity,
            ElectricityPerDay,
            ElectricityPerNight,
            HotWaterOfHeatCarrier,
            HotWaterThermalEnergy
        }
    }
}
