using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Abstraction
{

    //PaymentProcessor
    //Creează o clasă PaymentProcessor cu o metodă publică ProcessPayment(decimal amount). Aceasta trebuie să:
    //- Valideze suma
    //- Autentifice utilizatorul
    //- Proceseze plata
    //- Genereze o confirmare

    // internal -- vizibila doar in acest proiect "learnProject" 
    // public -- vizibila in toate proiectele

    internal class PaymentProcessor
    {
        public void ProcessPayment(decimal amount) {
            Verify(amount);
            Authenticate();
            ConfirmPay(amount);
            ProcessPay();
        }

        private void Verify(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount can't be 0 or negative!");
            }
        }
        private void Authenticate()
        {
            Console.WriteLine("Authenticating user credentials...");
        }
        private void ProcessPay() {
            Console.WriteLine("Confirmation: User payment is done!");
        }
        private void ConfirmPay(decimal amount) {
            Console.WriteLine($"Validating payment amount: {amount}");
        }
    }
}
