using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Interfaces.exemplu
{
    internal interface ISerializer
    {
        string Serialize(object data);
        object Deserialize(string input);
    }
}
