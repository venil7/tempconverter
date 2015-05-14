using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TempConverter.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = culture;

            var oldWindow = Application.Current.MainWindow;
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            oldWindow.Close();
        }
    }
}
