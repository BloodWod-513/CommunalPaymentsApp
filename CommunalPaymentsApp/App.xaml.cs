using CommunalPaymentsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CommunalPaymentsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Tariff> tariffs = new List<Tariff>();
        public App()
        {
            ApplicationContext db = new();
            tariffs = db.Tariffs.ToList();
        }
    }
}
