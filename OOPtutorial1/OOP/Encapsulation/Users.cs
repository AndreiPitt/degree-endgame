using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Encapsulation
{
    public class Users
    {
        private string name;
        private string password;
        private string email;


        public Users(string name, string password, string email)
        {
            SetName(name);
            SetPassword(password);
            SetEmail(email);
        }

        public void ShowUser() { 
            Console.WriteLine($"Username name is {name}.");
        }
        public string GetPassword()
        {
            return password;
        }

        public void SetName(string name) {
            if (name.Length < 3) { 
                throw new ArgumentException("Username must have minimum 3 caracters");
            }
            this.name = name;
        }

        public void SetPassword(string password) {
            this.password = password;
        }

        public void SetEmail(string email) { 
            this.email = email;
        }
    }
}
