using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Abstraction
{
    public class EmailService
    {
        public void SendEmail()
        {
            Connect();
            Authentificate();
            Console.WriteLine("Sending email...");
            Disconnect();
        }

        private void Connect()
        {
            Console.WriteLine("Connecting to email server...");
        }
        private void Disconnect()
        {
            Console.WriteLine("Disconnecting from email server...");
        }

        private void Authentificate() {
            Console.WriteLine("Authentificating...");
        
        }
    }
}
