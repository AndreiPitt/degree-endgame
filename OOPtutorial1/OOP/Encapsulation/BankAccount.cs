using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnProject.OOPtutorial1.OOP.Encapsulation
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            Deposit(balance);
        }

        public decimal GetBalance() { 
            return balance;
        }

        public void Deposit(decimal amount) {
            if (amount <= 0) {
                throw new ArgumentException("Deposit amount must be positive");
            }
            balance = amount;
        }

        public void Withdraw(decimal amount) {
            if (amount <= 0) {
                throw new ArgumentException("Withdraw amount must be positive");
            }
            if (amount > balance) {
                throw new InvalidOperationException("Insufficient funds.");
            }
            balance = amount;
        }

    }
}
