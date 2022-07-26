
using System.Windows;

namespace CommunalPaymentsApp.ValidationTools
{
    public static class ValidationPrinter
    {
        public static void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
