using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using NumberGeretions.Commands;
using NumberGeretions.Model;

namespace NumberGeretions.ViewModel
{
    class MiniLottoViewModel : INotifyPropertyChanged
    {

        private MiniLottoModel _miniLottoModel;
        public MiniLottoModel model { get { return _miniLottoModel; } set { _miniLottoModel = value; OnPropertyChange(nameof(model)); } }

        public ICommand command { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Generate(object obj)
        {
            int ManyNumbers = Convert.ToInt32(model.HowManysy);
            this.NumbersGeneration(ManyNumbers);
            
        }

        public bool CanEx(object obj)
        {
            return true;
        }
        public MiniLottoViewModel(int HowMany =1)
        {
            model = new MiniLottoModel();
            model.Numbers = new ObservableCollection<string> { };
            command = new RelayCommands(Generate, CanEx) ;
            NumbersGeneration(HowMany);
            
           
        }

        public void NumbersGeneration(int HowMany = 1, string test = "no tam test")
        {
            model.Numbers.Clear();
            int iteretion = 0; 
            Random randNum = new Random();
            while(iteretion < HowMany)
            {
                int AllNums = 0;
                int[] temptab = new int[5];
                int[] SortedTab = new int[5];
                string ConvertedTab;
                bool isFinish = false;
                bool isDuplicated = false;
                 
                
                while(!isFinish)
                {
                    isDuplicated = false;
                    int RandomNumber = randNum.Next(0, 42);

                    for(int i = 0; i < AllNums; i++)
                    {
                        if(RandomNumber == temptab[i])
                        {
                            isDuplicated = true;break;
                        }
                    }

                    if(!isDuplicated)
                    {
                        temptab[AllNums] = RandomNumber;
                        AllNums++;
                    }

                    if(AllNums > 4)
                    {
                        isFinish = true;
                    }

                }

                SortedTab = sort(temptab);

                ConvertedTab = ConvertToString(SortedTab);  

                model.Numbers.Add(ConvertedTab);

                


                iteretion++;


            }

        }

        private int[] sort(int[] NotSortedTab)
        {
            int[] sortTab = new int[NotSortedTab.Length];
            int LowestNumber = 50;
            int iteration = 0;
            int AnotherIter = 0;

            for(int i = 0; i< NotSortedTab.Length; i++)
            {
                LowestNumber = 50;
               
                for(int j = 0; j < NotSortedTab.Length; j++)
                {
                    if(LowestNumber > NotSortedTab[j] && NotSortedTab[j] != 0)
                    {
                        LowestNumber = NotSortedTab[j];
                        iteration = j;
                    }
                }
                sortTab[AnotherIter] = LowestNumber;
                AnotherIter++;
                NotSortedTab[iteration] = 0;
            }
            return sortTab;

        }

        private string ConvertToString(int[] sortedNums)
        {
            string Converted = string.Empty;
            string tempstring = string.Empty;
            Converted += "Numbers: ";
            for (int i =0; i< sortedNums.Length; i++)
            {
                tempstring = Convert.ToString(sortedNums[i]);
                Converted += " " + tempstring;
            }
            return Converted;
        }

    }
}
