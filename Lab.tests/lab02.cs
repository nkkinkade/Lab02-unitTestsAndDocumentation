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
            decimal balance = Program.balance;
            // Act
            decimal result = Program.ViewBalance(balance);
            // Assert
            Assert.Equal(result, Program.balance);
        }

        [Fact]
        public void CanWithdraw()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Withdraw(10, 10);
            // Assert
            Assert.Equal(10, Program.balance);
        }

        [Fact]
        public void CanNotWithdrawBalance()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Withdraw(22, 42);
            // Assert
            Assert.Equal(0, Program.balance);
        }

        [Theory]
        [InlineData(30, 20, 10)]
        [InlineData(20, 30, 0)]
        [InlineData(30, -20, 30)]
        public void WithdrawTest(decimal balance, decimal withraw, decimal expect)
        {
            decimal result = Program.Withdraw(balance, withraw);
            Assert.Equal(result, expect);
        }

        [Theory]
        [InlineData(30, 80, 110)]
        [InlineData(20, 30, 50)]
        [InlineData(30, -20, 30)]
        public void DepositTest(decimal balance, decimal deposit, decimal expect)
        {
            decimal result = Program.Deposit(balance, deposit);
            Assert.Equal(result, expect);
        }

        [Fact]
        public void CanDeposit()
        {
            // Arrange
            Program.balance = 20;
            // Act
            Program.Deposit(20, 10);
            // Assert
            Assert.Equal(30, Program.balance);
        }
    }
}
