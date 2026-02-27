using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using WpfLearn.Models;

namespace WpfLearn.ViewModel
{
    internal class UserViewModel
    {
        private IList<User> _userList;

        public UserViewModel()
        {
            _userList = new List<User> {
            new User {Name = "Andrei", Age = 23 },
            new User {Name = "Pitt", Age = 23 }
            };
        }

        public IList<User> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }

        private ICommand mUpdater;

        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                // Code implementation for execution
            }
        }
    }
}
