using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.Proiect
{
    public class Day
    {
        private DateTime _date;
        private bool _isWorkoutDay;
        private Workout _workout;
        private Dictionary<string, double> _macros = new Dictionary<string, double>();

        public Day(DateTime date, double proteins, double carbohydrates, double fats, bool isWorkoutDay = false) 
        {
            _date = date;
            SetMacros(proteins, carbohydrates, fats);

            if (isWorkoutDay) 
            {
                _isWorkoutDay = isWorkoutDay;
                _workout = new Workout(date);
            }
        }

        public Workout GetWorkout()
        {
            if (_isWorkoutDay)
                return _workout;
            throw new InvalidOperationException("No workout scheduled for this day.");
        }

        private void SetMacros(double proteins, double carbohydrates, double fats) 
        {
            if (proteins < 0 || carbohydrates < 0 || fats < 0)
            {
                throw new ArgumentException("Macro values must be non-negative.");
            }
            _macros.Add("proteins", proteins);
            _macros.Add("carbohydrates", carbohydrates);
            _macros.Add("fats", fats);
        }

    }
}
