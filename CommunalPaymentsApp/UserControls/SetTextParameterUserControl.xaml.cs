using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommunalPaymentsApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SetTextParameterUserControl.xaml
    /// </summary>
    public partial class SetTextParameterUserControl : UserControl
    {
        public SetTextParameterUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string ParameterText { get; set; }
    }
}
