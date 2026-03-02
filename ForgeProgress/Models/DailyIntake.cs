using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeProgress.Models
{
    class DailyIntake
    {
        public DateTime Date { get; set; }
        public double BodyWeight { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double TotalCalories { get; set; }

    }
}
