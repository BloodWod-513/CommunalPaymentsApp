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
        public DbSet<Tariff> Tariffs => Set<Tariff>();
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
                    new Tariff("ХВС", 35.78, 4.85, Tariff.UnitsMesurement.CubicMeter),
                    new Tariff("ГВС", 158.98, 4.01, Tariff.UnitsMesurement.CubicMeter),
                    new Tariff("ЭЭ", 4.28, 164, Tariff.UnitsMesurement.Kilowatt),
                    new Tariff("ЭЭ день", 4.9, null, Tariff.UnitsMesurement.Kilowatt),
                    new Tariff("ЭЭ ночь", 2.31, null, Tariff.UnitsMesurement.Kilowatt),
                    new Tariff("ГВС Теплоноситель", 35.38, 4.01, Tariff.UnitsMesurement.CubicMeter),
                    new Tariff("ГВС Тепловая энергия", 998.69, 0.05349, Tariff.UnitsMesurement.Gigacalories),
                });
        }
    }
}
