// See https://aka.ms/new-console-template for more information
namespace Encapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            // Declaring the Object of the BankAccount class
            BankAccount b1 = new BankAccount(1000);
            b1.Deposit(100);
            b1.Withdrawl(600);
            decimal r = b1.getBalance();
            Console.WriteLine("The Final balance --> " + r);

            BankAc b2 = new BankAc();
            b2.Balance = 1000;
            b2.Deposit(100);
            b2.Withdrawl(600);
            Console.WriteLine("The Final balance by getter setter --> " + b2.Balance);

            Console.ReadLine();
        }
    }
}

