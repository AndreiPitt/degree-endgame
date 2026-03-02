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
        private string _pathDailyFile = "C:\\Users\\gf0sg\\Desktop\\Licenta\\sharp\\degree-endgame\\Invatare\\ForgeProgress\\Services\\daily.json";
        private string _pathMeasurementsFile = "C:\\Users\\gf0sg\\Desktop\\Licenta\\sharp\\degree-endgame\\Invatare\\ForgeProgress\\Services\\measurements.json";        
        
        private DailyIntakeViewModel _currentEntry;
        private MeasurementsViewModel _currentMeasurement;

        //private DailyIntakeViewModel _selectedEntry;

        #region Properties
        public ObservableCollection<DailyIntakeViewModel> Entries { get; set; }
        public ObservableCollection<MeasurementsViewModel> Measurements { get; set; }
        public DailyIntakeViewModel CurrentEntry
        {
            get => _currentEntry;
            set
            {
                _currentEntry = value;
                OnPropertyChanged(nameof(CurrentEntry));
            }
        }

        public MeasurementsViewModel CurrentMeasurement 
        {
            get => _currentMeasurement;
            set
            {
                _currentMeasurement = value;
                OnPropertyChanged(nameof(CurrentMeasurement));
            }
        }

        /*
        public DailyIntakeViewModel SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                _selectedEntry = value;   
                OnPropertyChanged(nameof(SelectedEntry));
            }
        }
        */
        #endregion

        public MainViewModel()
        {
            ProgressRepository repoDaily = new ProgressRepository(_pathDailyFile);
            ProgressRepository repoMeasurements = new ProgressRepository(_pathMeasurementsFile);

            Entries = new ObservableCollection<DailyIntakeViewModel>(
                repoDaily.Load<DailyIntake>().Select(e => new DailyIntakeViewModel(e))
            );

            Measurements = new ObservableCollection<MeasurementsViewModel>(
                repoMeasurements.Load<Measurements>().Select(e => new MeasurementsViewModel(e))  
            );

            CurrentEntry = new DailyIntakeViewModel(
                new DailyIntake{ Date = DateTime.Today }
            );

            CurrentMeasurement = new MeasurementsViewModel(
                new Measurements {Date = CurrentEntry.Date } // vreau ca datepicker sa fie comun
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

            AddMeasurementCommand = new RelayCommand(o =>
            {
                Measurements.Add(new MeasurementsViewModel(new Measurements
                                            { Date = CurrentEntry.Date, // Am folosit CurrentEntry in loc de CurrentMeasurement pentru ca ambele sa aibe aceasi data
                                            WaistSizeCm = CurrentMeasurement.WaistSizeCm }
                
                ));
                CurrentMeasurement = new MeasurementsViewModel(
                    new Measurements {Date = DateTime.Today }
                );
            });

            SaveCommand = new RelayCommand(o =>
            {
                repoDaily.Save(Entries.Select(vm => vm.DayIntake).ToList());
                repoMeasurements.Save(Measurements.Select(vm => vm.DailyMeasurements).ToList());

            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand AddEntryCommand { get; }
        public ICommand AddMeasurementCommand { get; }
        public ICommand SaveCommand { get; }

    }
}
