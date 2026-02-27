using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Interfaces.exemplu
{
    internal class CsvSerializer : ISerializer
    {
        public string Serialize(object data)
        {
            return "Serializarea CSV a avut loc cu succes!";
        }

        public object Deserialize(string input)
        {
            return "Deserializarea CSV a avut loc cu succes!";
        }
    }
}
