using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class BankAccount
    {
        // Declaring the private Fields
        private decimal balance;

        // Declaring the Constructor to set the data 
        public BankAccount(decimal Initialbalance)
        {
            balance = Initialbalance;
        }

        // Declaring the Method for the Deposit
        public void Deposit(decimal amt)
        {
            balance = balance + amt;
        }

        // Declaring the Method for the Withdrwal
        public void Withdrawl(decimal amt)
        {
            if(balance >= amt)
            {
                balance = balance - amt;
            }
            else
            {
                Console.WriteLine("You have the Limited Balance");
            }
        }

        // Declaring the Method to get the balance
        public decimal getBalance() { return balance; }
    }
}
