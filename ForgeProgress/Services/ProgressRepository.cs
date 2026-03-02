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

        public List<T> Load<T>()
        {
            List<T> entries = new List<T>();

            if (File.Exists(FilePath))
            {
                string jsonString = File.ReadAllText(FilePath);
                entries = JsonSerializer.Deserialize<List<T>>(jsonString);
                return entries ?? new List<T>();
            }

            return entries;
        }


        public void Save<T>(List<T> entries)
        {
            string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, jsonString);
        }
    }
}
