using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab
{
     public class Program
    {
        public static double balance = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine(ViewBalance(balance));
        }

        public static double ViewBalance(double balance)
        {
            return balance;
        }

        /// <summary>
        /// Withdraws money from ATM. Sets balance to a lower amount
        /// </summary>
        /// <param name="amount">amount to be withdrawn</param>
        /// <returns>total balance affter transcation</returns>
        public static string Withdraw(double amount)
        {
            // Functionality: Subtracts money from the balance
            // Do not allow the user to withdraw more money than what’s available
            // Do not allow the user to withdraw a value less than or equal to zero
            if (amount > balance)
            {
                return $"{amount} is greater than your balance of {balance}";
            }
            if (amount <= 0)
            {
                return "You are trying to withdraw an invalid amount";
            }
            balance = balance - amount;

            //return "Withdrawal was successful and your new balance is: " + balance;
            return "Withdrawal was successful";

        }

        public static bool Deposit(double amount)
        {
            // Functionality: Adds money to the balance   CanDepositMoney
            // Do not allow the user to deposit a negative amount   
            if (amount > 0)
            {
                balance = balance + amount;
                return true;
            }
            return false;
        }
    }
}
