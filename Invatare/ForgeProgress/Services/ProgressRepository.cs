using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.DirectoryServices;
using ForgeProgress.Models;

namespace ForgeProgress.Services
{
    class ProgressRepository
    {
        public string FilePath { get; set; }

        public ProgressRepository(string file)
        {
            FilePath = file;
        }

        public List<DailyIntake> Load() {

            List<DailyIntake> entries = new List<DailyIntake>();
            if (File.Exists(FilePath))
            {
                string jsonString = File.ReadAllText(FilePath);
                entries = JsonSerializer.Deserialize<List<DailyIntake>>(jsonString);
                return entries == null ? new List<DailyIntake>() : entries;
            }
            else return entries;  
        }

        public void Save(List<DailyIntake> entries) {
            string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FilePath, jsonString);
        }
    }
}
