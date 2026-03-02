using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeProgress.Models;

namespace ForgeProgress.ViewModels
{
    internal class MeasurementsViewModel : INotifyPropertyChanged
    {
        private Measurements _dailyMeasurements;

        public Measurements DailyMeasurements 
        {
            get => _dailyMeasurements;
            set 
            {
                _dailyMeasurements = value;
                OnPropertyChanged(nameof(DailyMeasurements));
            }
        }

        public DateTime Date 
        {
            get => _dailyMeasurements.Date;
            set
            {
                _dailyMeasurements.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public double WaistSizeCm
        {
            get => _dailyMeasurements.WaistSizeCm;
            set
            {
                _dailyMeasurements.WaistSizeCm = value;
                OnPropertyChanged(nameof(WaistSizeCm));
            }
        }

        // Constructor
        public MeasurementsViewModel(Measurements entry) {
            DailyMeasurements = entry;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
