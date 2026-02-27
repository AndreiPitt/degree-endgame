using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfLearn.Models
{
    internal class User : INotifyPropertyChanged
    {

        private string _name;
        private int _age;
        public string Name  
        {
            get 
            {
                return _name;
            }
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        public int Age 
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
