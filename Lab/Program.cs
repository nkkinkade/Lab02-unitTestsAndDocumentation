using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab
{
    public class Program
    {
        public static decimal balance = 10;
        public static void Main(string[] args)
        {
            ChooseMethod();
            Console.WriteLine(ViewBalance(balance));
        }

        public static decimal ViewBalance(decimal balance)
        {
            Console.WriteLine($"Available Balance: ${balance}");
            return balance;
        }

        /// <summary>
        /// Withdraws money from ATM. Sets balance to a lower amount
        /// </summary>
        /// <param name="amount">amount to be withdrawn</param>
        /// <returns>total balance affter transcation</returns>
        public static decimal Withdraw(decimal balance, decimal withdrawAmount)
        {
            // Functionality: Subtracts money from the balance
            // Do not allow the user to withdraw more money than what’s available
            // Do not allow the user to withdraw a value less than or equal to zero
            if (NotNegative(withdrawAmount) && balance > withdrawAmount)
            {
                balance = balance - withdrawAmount;
                Console.WriteLine($"Withdraw Amount: ${withdrawAmount} ");
                Console.WriteLine($"Remaing Balance: ${balance}");
                Program.balance = balance;
                return balance;
            }
            if (NotNegative(withdrawAmount) && balance < withdrawAmount)
            {
                Console.WriteLine($"Could only withraw ${balance}");
                Console.WriteLine("Remaining Balance: $0");
                balance = 0;
                Program.balance = balance;
                return balance;
            }
            else
            {
                Console.WriteLine("Couldn't process request.");
                Program.balance = balance;
                return balance;
            }
        }

        public static decimal Deposit(decimal balance, decimal depositAmount)
        {
            // Functionality: Adds money to the balance   CanDepositMoney
            // Do not allow the user to deposit a negative amount   
            if (NotNegative(depositAmount))
            {
                balance = balance + depositAmount;
                Console.WriteLine($"Deposit Amount: ${depositAmount} ");
                Console.WriteLine($"New Balance: ${balance}");
                Program.balance = balance;
                return balance;
            }
            else
            {
                Console.WriteLine("Couldn't process request.");
                return balance;
            };
        }

        static public decimal WithrawRequest()
        {
            Console.WriteLine("Select an amount to withdraw");
            Console.WriteLine($"Current Balance: ${balance}");
            string input = Console.ReadLine();
            decimal withdraw = Convert.ToDecimal(input);
            return Withdraw(balance, withdraw);
        }

        static public decimal DepositRequest()
        {
            Console.WriteLine("Select an amount to deposit");
            string input = Console.ReadLine();
            decimal deposit = Convert.ToDecimal(input);
            return Deposit(balance, deposit);
        }
        static public void ChooseMethod()
        {
            int run = 0;
            while (run == 0)
            {
                Console.WriteLine("Choose an option.");
                Console.WriteLine("-Withdraw");
                Console.WriteLine("-Deposit");
                Console.WriteLine("-Check Balance");
                string input = Console.ReadLine().ToLower();
                if (input == "withdraw" || input == "1")
                {
                    WithrawRequest();
                    continue;
                }
                if (input == "deposit" || input == "2")
                {
                    DepositRequest();
                    continue;
                }
                if (input == "check balance" || input == "3")
                {
                    ViewBalance(balance);
                    continue;
                }
                if (input == "")
                {
                    break;
                }
            }
        }
        public static bool NotNegative(decimal value)
        {
            if (value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
