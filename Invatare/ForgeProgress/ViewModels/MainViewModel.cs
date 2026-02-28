using ForgeProgress.Commands;
using ForgeProgress.Models;
using ForgeProgress.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace ForgeProgress.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _pathFile = "C:\\Users\\gf0sg\\Desktop\\Licenta\\sharp\\degree-endgame\\Invatare\\ForgeProgress\\Services\\db.json";
        private DailyIntakeViewModel _selectedEntry;
        private DailyIntakeViewModel _currentEntry;
        public ObservableCollection<DailyIntakeViewModel> Entries { get; set; }
        public DailyIntakeViewModel CurrentEntry
        {
            get => _currentEntry;
            set
            {
                _currentEntry = value;
                OnPropertyChanged(nameof(CurrentEntry));
            }
        }


        public DailyIntakeViewModel SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                _selectedEntry = value;   
                OnPropertyChanged(nameof(SelectedEntry));
            }
        }

        public MainViewModel()
        {
            ProgressRepository repo = new ProgressRepository(_pathFile);
            Entries = new ObservableCollection<DailyIntakeViewModel>(
                repo.Load().Select(e => new DailyIntakeViewModel(e))
            );
            CurrentEntry = new DailyIntakeViewModel(
                new DailyIntake{ Date = DateTime.Today }
            );

            AddEntryCommand = new RelayCommand(o =>
            {
                Entries.Add(new DailyIntakeViewModel(new DailyIntake 
                                            {BodyWeight = CurrentEntry.BodyWeight,
                                             Date = CurrentEntry.Date,
                                             TotalCalories = CurrentEntry.TotalCalories,
                                             Protein = CurrentEntry.Protein,
                                             Carbohydrates= CurrentEntry.Carbohydrates,
                                             Fats= CurrentEntry.Fats }
                ));
                CurrentEntry = new DailyIntakeViewModel(
                    new DailyIntake { Date = DateTime.Today }
                );
            });

            SaveCommand = new RelayCommand(o =>
            {
                repo.Save(Entries.Select(vm => vm.DayIntake).ToList());

            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand AddEntryCommand { get; }
        public ICommand SaveCommand { get; }

    }
}
