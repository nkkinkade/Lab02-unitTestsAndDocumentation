using Lab;
using System;
using Xunit;

namespace Lab.Tests
{
    public class lab02
    {
        [Fact]
        public void ViewBalanceTest()
        {
            // Arrange
            double balance = Program.balance;
            // Act
            double result = Program.ViewBalance(balance);
            // Assert
            Assert.Equal(result, Program.balance);
        }

        [Fact]
        public void CanWithdraw()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Withdraw(10.00);
            // Assert
            Assert.Equal(10, Program.balance);
        }

        [Fact]
        public void CanNotWithdrawBalance()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Withdraw(21.00);
            // Assert
            Assert.Equal(20, Program.balance);
        }

        [Theory]
        [InlineData("Withdrawal was successful", 20.00, 30.00)]
        [InlineData("You are trying to withdraw an invalid amount", 0, 500)]
        [InlineData("10 is greater than your balance of 5", 10.00, 5.00)]
        public void CannotOverdraft(string message, double amount, double balance)
        {
            // Arrange
            Program.balance = balance;
            // Act
            string response = Program.Withdraw(amount);
            // Assert
            Assert.Equal(message, response);
        }

        [Fact]
        public void CanDeposit()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Deposit(10.00);
            // Assert
            Assert.Equal(30, Program.balance);
        }
    }
}
