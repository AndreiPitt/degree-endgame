using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Abstraction
{
    //Creează o clasă FileUploader care are o metodă publică UploadFile(string filePath). Aceasta trebuie să:
    //- Verifice dacă fișierul există
    //- Se conecteze la server
    //- Trimită fișierul
    //- Închidă conexiunea

    public class FileUploader
    {
        private string path = "pitt/secret";
        public void UploadFile(string filePath) {
            Verify(filePath);
            Connect();
            SendFile(filePath);
            Disconnect();
        }


        private void Verify(string filePath) {
            if (filePath != path) {
                throw new AccessViolationException("This path doesn't exist!");
            }
        }
        private void Connect() {
            Console.WriteLine("Connecting...");
        }

        private void SendFile(string filePath) {
            Console.WriteLine($"Uploading file to server: {filePath}");
        }

        private void Disconnect() { 
            Console.WriteLine("Disconnecting...");
        }
    }
}
