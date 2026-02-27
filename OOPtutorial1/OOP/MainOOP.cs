using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learnProject.Inheritance;
using learnProject.OOPtutorial1.OOP.Abstraction;
using learnProject.OOPtutorial1.OOP.Encapsulation;

namespace learnProject.OOPtutorial1.OOP
{
    internal class MainOOP
    {
        public static void Show()
        {
            //🧠 Encapsulation

            BankAccount bankAccount = new BankAccount(100);
            Console.WriteLine(bankAccount.GetBalance());
            bankAccount.Deposit(200);
            Console.WriteLine(bankAccount.GetBalance());
            bankAccount.Withdraw(50);
            Console.WriteLine(bankAccount.GetBalance());

            Users user1 = new Users("Pitt", "pit123", "pit@gmail.com");
            Console.WriteLine(user1.GetPassword());


            //🧠 Abstraction - reduce complexity by hiding unnecessary details.

            EmailService emailService = new EmailService();
            emailService.SendEmail();

            FileUploader uploader = new FileUploader();
            uploader.UploadFile("pitt/secret");

            //🧠 Inheritance - involves creating new classes(subclasses or derived classes) based on existing classes(superclasses
            //or base classes). Subclasses inherit properties and behaviors from their superclasses and can also add new features or override existing
            //ones.Inheritance is often described in terms of an "is-a" relationship.

             var car = new Car();
            //Shared
            car.Brand = "Audi";
            car.Start();
            car.Stop();

            //Unique
            car.NumberOfDoors = 4;

            var tir = new Truck("Scania", 2025);

            tir.Brand = "Volvo";
            tir.Year = 2025;
            tir.LoadCapacity = 5000;
            tir.HasTrailer = true;

            tir.Start();
            tir.Stop();

            //🧠 Polymorphism - is the abillity of an object to take many forms.
            //    virtual keyword este o propietate care arata ca o metoda poate fi suprascrisa de orice subclasa
            //    override


             //Generic
             List<object> list = new List<object>();
             list.Add(new Car { Brand = "Audi", Model = "A4 B8", Year = 2011 }); // nu are constructor
             list.Add(new Bike { Brand = "Bmx", Year = 2024 }); // nu are constructor
             list.Add(new Truck("Volvo", 2025)); // are constructor

            foreach (var vehicle in list)
            {
                if (vehicle is Car)
                {
                    var veh = (Car)vehicle;
                    veh.Start();
                 }
                else if (vehicle is Bike)
                {
                    var veh = (Bike)vehicle;
                    veh.Start();
                }
                else if (vehicle is Truck)
                {
                    var veh = (Truck)vehicle;
                    veh.Start();
                 }
             }

            // OR

            //Specific
            List<Vehicle> cars = new List<Vehicle>(); // e posibil datorita mostenirii
            cars.Add(new Car { Brand = "Audi", Model = "A4 B8", Year = 2011 }); // nu are constructor
            cars.Add(new Bike { Brand = "Bmx", Year = 2024 }); // nu are constructor
            cars.Add(new Truck("Volvo", 2025)); // are constructor

            foreach (var vehicle in cars)
            {
                vehicle.Start();
            }
        }
    }
}
