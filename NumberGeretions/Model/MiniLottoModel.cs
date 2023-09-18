using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGeretions.Model
{
    class MiniLottoModel : ObservableCollection<string>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        // private List<string> _Numbers;
        public ObservableCollection<string> Numbers { get; set; }

        private  string _howManysy;
        public  string HowManysy { get { return _howManysy; } set { _howManysy = value; OnPropertyChange(nameof(HowManysy)) ; } }

        public MiniLottoModel() : base()
        {
            Numbers = new ObservableCollection<string>();
        }

        public void OnPropertyChange(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        
    }


}
