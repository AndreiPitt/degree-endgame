using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Interfaces.exemplu
{
    internal class Report
    {
        private ISerializer _serializer;

        public Report(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Serialize(object data) {
            _serializer.Serialize(data);
        }
        public void Deserialize(string input) {
            _serializer.Deserialize(input);
        }
    }
}
