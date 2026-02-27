using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Interfaces.exemplu
{
    internal class JsonSerializer : ISerializer
    {
        public string Serialize(object data) {
            return "Serializarea Jsonului a avut loc cu succes!";
        }

        public object Deserialize(string input) {
            return "Deserializarea Jsonului a avut loc cu succes!";
        }
    }
}
