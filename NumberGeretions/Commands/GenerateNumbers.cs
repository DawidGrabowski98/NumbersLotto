using NumberGeretions.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NumberGeretions.Commands
{
    class GenerateNumbers : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MiniLottoViewModel model = (MiniLottoViewModel)parameter;
            MessageBox.Show(parameter.ToString());
            model.NumbersGeneration(5);
            
            Application.Current.MainWindow.DataContext = model;
        }
    }
}
