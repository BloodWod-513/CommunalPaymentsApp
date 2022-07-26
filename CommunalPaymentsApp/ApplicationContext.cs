using CommunalPaymentsApp.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Tariff> Tariffs { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tariff>().HasData(
                new Tariff[]
                {
                    new Tariff("ХВС", 35.78, 4.85, Tariff.UnitsMesurement.CubicMeter, Tariff.TypeTariff.ColdWater) { Id = 0 },
                    new Tariff("ГВС", 158.98, 4.01, Tariff.UnitsMesurement.CubicMeter, Tariff.TypeTariff.HotWater) { Id = 1 },
                    new Tariff("ЭЭ", 4.28, 164, Tariff.UnitsMesurement.Kilowatt, Tariff.TypeTariff.Electricity) { Id = 2 },
                    new Tariff("ЭЭ день", 4.9, null, Tariff.UnitsMesurement.Kilowatt, Tariff.TypeTariff.ElectricityPerDay) { Id = 3 },
                    new Tariff("ЭЭ ночь", 2.31, null, Tariff.UnitsMesurement.Kilowatt, Tariff.TypeTariff.ElectricityPerNight) { Id = 4 },
                    new Tariff("ГВС Теплоноситель", 35.78, 4.01, Tariff.UnitsMesurement.CubicMeter, Tariff.TypeTariff.HotWaterOfHeatCarrier) { Id = 5 },
                    new Tariff("ГВС Тепловая энергия", 998.69, 0.05349, Tariff.UnitsMesurement.Gigacalories, Tariff.TypeTariff.HotWaterThermalEnergy) { Id = 6 },
                });
        }
    }
}
