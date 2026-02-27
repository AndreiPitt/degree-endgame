using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeProgress.Models
{
    class DailyIntake
    {
        private double _bodyWeight;
        private double _protein;
        private double _fats;
        private double _carbohydrates;
        private double _totalCalories;

        public double BodyWeight { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public double TotalCalories { get; set; }

    }
}
