
using learnProject.Proiect;
using Microsoft.VisualBasic;

namespace learnProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var set1 = new TrainingSet("Impins inclinat", 10.0, 12, TrainingSet.MuscleGroup.Chest);
            Workout antrenament = new Workout(DateTime.Today);
            for (int i = 0; i < 4; i++)
            {
                antrenament.AddSet(new TrainingSet("Impins inclinat", 10.0, 12, TrainingSet.MuscleGroup.Chest));
                antrenament.AddSet(new TrainingSet("Tractiuni", 22.0, 8, TrainingSet.MuscleGroup.Back));
            }
            antrenament.AddSet(set1);
            Console.WriteLine(antrenament.GetTotalVolume());
            antrenament.PrintVolumeByMuscle();
        }
    }
}
