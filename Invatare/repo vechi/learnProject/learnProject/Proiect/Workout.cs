using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.Proiect
{
    public class Workout
    {
        private DateTime _workoutDate;
        private List<TrainingSet> _trainingSets = new List<TrainingSet>();
        private Dictionary<TrainingSet.MuscleGroup, double> _volumeByMuscle = new Dictionary<TrainingSet.MuscleGroup, double>();
        private double _totalVolumeKg;
        private double _estimated1RM;
        private double _intensityScore;

        public Workout(DateTime date) 
        { 
            _workoutDate = date;
            _totalVolumeKg = 0;
        }

        public void AddSet(TrainingSet set)
        { 
            _trainingSets.Add(set);
            _totalVolumeKg += set.GetExerciseVolume();

            var targetMuscle = set.GetTargetMuscle();

            if (_volumeByMuscle.ContainsKey(targetMuscle))
            {
                _volumeByMuscle[targetMuscle]+= set.GetExerciseVolume();
            }
            else
            {
                _volumeByMuscle.Add(targetMuscle, set.GetExerciseVolume());
            }
        }

        public void RemoveSetAt(int index)
        {
            if (index >= 0 && index < _trainingSets.Count)
            {
                TrainingSet setToRemove = _trainingSets[index];
                TrainingSet.MuscleGroup targetMuscle = setToRemove.GetTargetMuscle();
                double setVolume = setToRemove.GetExerciseVolume();

                _totalVolumeKg -= setVolume;
                _trainingSets.RemoveAt(index);

                if (_volumeByMuscle.ContainsKey(targetMuscle))
                {
                    _volumeByMuscle[targetMuscle] -= setVolume;

                    if (_volumeByMuscle[targetMuscle] <= 0.0001)
                    {
                        _volumeByMuscle.Remove(targetMuscle);
                    }
                }
            }
        }

        public List<TrainingSet> GetSets() 
        { 
            return _trainingSets;
        }

        public DateTime GetDate()
        {
            return _workoutDate;
        }

        public double GetTotalVolume() 
        {
            return _totalVolumeKg;
        }

        public void PrintVolumeByMuscle() 
        {
            foreach (var set in _volumeByMuscle) 
            {
                Console.WriteLine($"Muscle Group: {set.Key} --> Volume: {set.Value} kg.");
            }
        
        }

        private void Compute1RM()
        {
            //e1RM (Epley) = 20 × (1 + 0.0333 × 12) ≈ 28 kg
            double e1RM = 0; 
            foreach (var set in _trainingSets) 
            {
                e1RM += set.GetExerciseWeight() * (1 + 0.0333 * 12);
            }
            _estimated1RM = e1RM;
        }
    }
}
