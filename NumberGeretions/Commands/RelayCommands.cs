using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NumberGeretions.Commands
{
    public class RelayCommands : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public Action<object> _Execute { get; set; }
        public Predicate<object> _CanExecute { get; set; }

        public RelayCommands(Action<object> Execute,Predicate<object> CanExecute) 
        {

            _Execute = Execute;
            _CanExecute = CanExecute;
        
        }


        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);  
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);    
        }
    }
}
