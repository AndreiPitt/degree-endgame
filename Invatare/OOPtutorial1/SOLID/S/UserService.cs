using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.SOLID.S
{
    internal class UserService
    {
        public void Register(User user)
        {
            //Register user logic...

            //Send email
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail(user.Email, "Mesajul meu");
        }
    }
}
