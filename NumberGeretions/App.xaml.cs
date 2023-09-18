using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NumberGeretions.ViewModel;

namespace NumberGeretions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {

                DataContext = new MiniLottoViewModel()

            };
            MainWindow.Show();

            base.OnStartup(e);  
        }

    }
}
