using MVVM_project.Commands;
using MVVM_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MVVM_project.ViewModels
{
    class PersoanaViewModel : INotifyPropertyChanged
    {
        private Persoana _persoana;
        
        public Persoana Persoana
        {
            get => _persoana; 
            set 
            {
                _persoana = value;
                OnPropertyChanged(nameof(Persoana));
            }
        }

        public string Name
        {
            get => _persoana.Name;
            set
            {
                _persoana.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get => _persoana.Age;
            set
            {
                _persoana.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public PersoanaViewModel(Persoana persoana)
        {
            _persoana = persoana;

            SchimbaNumeCommand = new RelayCommand(o =>
            {
                Name = "Nume schimbat din ViewModel!";
            });

            IncrementeazaVarstaCommand = new RelayCommand(o =>
            {
                Age += 1;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ICommand SchimbaNumeCommand { get; }
        public ICommand IncrementeazaVarstaCommand { get; }



    }
}
