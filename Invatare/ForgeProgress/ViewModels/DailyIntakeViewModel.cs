using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeProgress.Models;

namespace ForgeProgress.ViewModels
{
    class DailyIntakeViewModel : INotifyPropertyChanged
    {
        private DailyIntake _dayIntake;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public DailyIntake DayIntake
        {
            get => _dayIntake;
            set
            {
                _dayIntake = value;
                OnPropertyChanged(nameof(DayIntake));
            }
        }

        public DailyIntakeViewModel() 
        {
            _dayIntake = new DailyIntake();
        
        }

        public DateTime Date 
        {
            get => DateTime.Now;
            set 
            {
                _dayIntake.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public double BodyWeight
        {
            get => _dayIntake.BodyWeight;
            set
            {

                if (value >= 0 && _dayIntake.BodyWeight != value)
                {
                    _dayIntake.BodyWeight = value;
                    OnPropertyChanged(nameof(BodyWeight));
                }
            }
        }

        public double Protein
        {
            get => _dayIntake.Protein;
            set
            {
                
                if (value >= 0 && _dayIntake.Protein != value)
                {
                    _dayIntake.Protein = value;
                    OnPropertyChanged(nameof(Protein));
                }
            }
        }

        public double Fats
        {
            get => _dayIntake.Fats;
            set
            {

                if (value >= 0 && _dayIntake.Fats != value)
                {
                    _dayIntake.Fats = value;
                    OnPropertyChanged(nameof(Fats));
                }
            }
        }

        public double Carbohydrates
        {
            get => _dayIntake.Carbohydrates;
            set
            {

                if (value >= 0 && _dayIntake.Carbohydrates != value)
                {
                    _dayIntake.Carbohydrates = value;
                    OnPropertyChanged(nameof(Carbohydrates));
                }
            }
        }

        public double TotalCalories
        {
            get => _dayIntake.TotalCalories;
            set
            {

                if (value >= 0 && _dayIntake.TotalCalories != value)
                {
                    _dayIntake.TotalCalories = value;
                    OnPropertyChanged(nameof(TotalCalories));
                }
            }
        }



    }
}
