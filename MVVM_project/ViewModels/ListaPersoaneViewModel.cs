using MVVM_project.Commands;
using MVVM_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MVVM_project.ViewModels
{
    class ListaPersoaneViewModel : INotifyPropertyChanged
    {
        private PersoanaViewModel _persoanaSelectata;
        public ObservableCollection<PersoanaViewModel> Persoane { get; }

        public PersoanaViewModel PersoanaSelectata
        {
            get => _persoanaSelectata;
            set
            {
                _persoanaSelectata = value;
                OnPropertyChanged(nameof(PersoanaSelectata));
            }
        }

        public ListaPersoaneViewModel() 
        {
            PersoanaSelectata = new PersoanaViewModel (new Persoana { Name = "Pitt", Age = 20 });
            Persoane = new ObservableCollection<PersoanaViewModel>()
            {
                PersoanaSelectata,
                new PersoanaViewModel ( new Persoana { Name = "Mihai", Age = 23 } ),
                new PersoanaViewModel ( new Persoana { Name = "Andrei", Age = 23 } )
            };

            AdaugaPersoanaCommand = new RelayCommand(o =>
            {
                Persoane.Add(new PersoanaViewModel(new Persoana {Name = "Persoana noua", Age = 20} ));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand AdaugaPersoanaCommand { get; }
    }
}
