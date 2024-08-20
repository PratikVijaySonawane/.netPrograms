using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class BankAc
    {

        // Declaring the balance value as the private
        private decimal balance;

        // Declaring the GET and SET 
        public decimal Balance 
        {
            set{
                balance = value;
            }
            get {
               return balance ;            
            }  
        }

        // Declaring the Method for the Deposit
        public void Deposit(decimal amt)
        {
            balance = balance + amt;
        }

        // Declaring the Method for the Withdrawl
        public void Withdrawl(decimal amt)
        {
            if (balance >= amt)
            {
                balance = balance-amt;
            }
            else
            {
                Console.WriteLine("You have very low bank balance ");
            }
        }

    }
}
