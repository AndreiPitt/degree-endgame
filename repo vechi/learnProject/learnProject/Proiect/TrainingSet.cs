using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.Proiect
{
    public class TrainingSet
    {
        public enum MuscleGroup
        {
            Chest,
            ShouldersFront,
            ShouldersSide,
            ShouldersRear,
            Back,
            Lumbar,
            Biceps,
            Triceps,
            Legs,
            Abs
        }

        private string _name;
        private double _loadKg;
        private uint _repCount;
        private double _volumeKg;
        private MuscleGroup _muscleGroup;


        public TrainingSet(string exerciseName, double weight, uint repetitions, MuscleGroup targetMuscle)
        {
            ValidateName(exerciseName);
            ValidateLoad(weight);
            ValidateReps(repetitions);
            ComputeVolume(_repCount, _loadKg);
            _muscleGroup = targetMuscle;
        }

        public string GetExerciseName()
        {
            return _name;
        }

        public double GetExerciseWeight() 
        {
            return _loadKg;
        }

        public uint GetExerciseReps() 
        { 
            return _repCount;
        }

        public double GetExerciseVolume() 
        {
            return _volumeKg;
        }

        public MuscleGroup GetTargetMuscle()
        {
            return _muscleGroup;
        } 

        private void ValidateName(string text)
        {
            if (String.IsNullOrEmpty(text)) 
            {
                throw new ArgumentNullException("This field cannot be empty. Please enter the exercise name.");
            }
            _name = text;
        }

        private void ValidateLoad(double weight) 
        {
            if (weight <= 0) {
                throw new ArgumentOutOfRangeException("This value must be greater than zero.");
            }
            _loadKg = weight;
        }

        private void ValidateReps(uint reps) 
        {
            if (reps == 0) 
            {
                throw new ArgumentOutOfRangeException("This value must be greater than zero.");
            }
            _repCount = reps;
        }

        private void ComputeVolume(uint reps, double weight) {
            _volumeKg = (double)reps * weight;
        }
    }
}
