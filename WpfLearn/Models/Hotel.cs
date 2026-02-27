using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn.Models
{
    class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name) 
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }
    }
}
