using ForgeProgress.Commands;
using ForgeProgress.Models;
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
        private string _pathFile = "C:\\Users\\gf0sg\\Desktop\\Licenta\\sharp\\degree-endgame\\Invatare\\ForgeProgress\\progress.json";
        private DailyIntake _selectedEntry;
        private DailyIntakeViewModel _currentEntry;
        public ObservableCollection<DailyIntake> Entries { get; set; }
        public DailyIntakeViewModel CurrentEntry
        {
            get => _currentEntry;
            set
            {
                _currentEntry = value;
                OnPropertyChanged(nameof(CurrentEntry));
            }
        }


        public DailyIntake SelectedEntry
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
            Entries = new ObservableCollection<DailyIntake>(repo.Load());
            CurrentEntry = new DailyIntakeViewModel(new DailyIntake { BodyWeight = 58.5, Protein = 130.0, Fats = 60, Carbohydrates = 250, TotalCalories = 2150, Date = DateTime.Now });

            AddEntryCommand = new RelayCommand(o =>
            {
                Entries.Add(new DailyIntake {BodyWeight = CurrentEntry.BodyWeight,
                                             Date = CurrentEntry.Date,
                                             TotalCalories = CurrentEntry.TotalCalories,
                                             Protein = CurrentEntry.Protein,
                                             Carbohydrates= CurrentEntry.Carbohydrates,
                                             Fats= CurrentEntry.Fats,                                    
                });
                CurrentEntry = new DailyIntakeViewModel(new DailyIntake { BodyWeight = 0, Protein = 0, Fats = 0, Carbohydrates = 0, TotalCalories = 0, Date = DateTime.Today });
                OnPropertyChanged(nameof(CurrentEntry));
            });

            SaveCommand = new RelayCommand(o =>
            {
                repo.Save(Entries.ToList());

            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand AddEntryCommand { get; }
        public ICommand SaveCommand { get; }

    }
}
