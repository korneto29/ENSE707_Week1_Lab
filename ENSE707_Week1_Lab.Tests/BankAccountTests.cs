using ENSE707_Week1_Lab;

namespace ENSE707_Week1_Lab.Tests;

public class BankAccountTests
{
    [Fact]
    public void Deposit_WithPositiveAmount_IncreasesBalance()
    {
        var account = new BankAccount("Student User", 100m);

        account.Deposit(50m);

        Assert.Equal(150m, account.Balance);
    }

    [Fact]
    public void Deposit_WithZeroAmount_ThrowsAndKeepsBalanceUnchanged()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(0m));

        Assert.Contains("greater than zero", exception.Message);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Deposit_WithNegativeAmount_ThrowsAndKeepsBalanceUnchanged()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-10m));

        Assert.Contains("greater than zero", exception.Message);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Withdraw_WithSufficientFunds_ReducesBalance()
    {
        var account = new BankAccount("Student User", 100m);

        var result = account.Withdraw(40m);

        Assert.True(result);
        Assert.Equal(60m, account.Balance);
    }

    [Fact]
    public void Withdraw_WithZeroAmount_ThrowsAndKeepsBalanceUnchanged()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(0m));

        Assert.Contains("greater than zero", exception.Message);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Withdraw_WithNegativeAmount_ThrowsAndKeepsBalanceUnchanged()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-10m));

        Assert.Contains("greater than zero", exception.Message);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Withdraw_WithInsufficientFunds_ThrowsAndKeepsBalanceUnchanged()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(150m));

        Assert.Contains("Insufficient funds", exception.Message);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void CalculateTransactionFee_WithPositiveAmount_ReturnsExpectedFee()
    {
        var account = new BankAccount("Student User", 100m);

        var fee = account.CalculateTransactionFee(100m);

        Assert.Equal(2m, fee);
    }

    [Fact]
    public void CalculateTransactionFee_WithZeroAmount_ReturnsZero()
    {
        var account = new BankAccount("Student User", 100m);

        var fee = account.CalculateTransactionFee(0m);

        Assert.Equal(0m, fee);
    }

    [Fact]
    public void CalculateTransactionFee_WithNegativeAmount_Throws()
    {
        var account = new BankAccount("Student User", 100m);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => account.CalculateTransactionFee(-10m));

        Assert.Contains("cannot be negative", exception.Message);
    }
}
