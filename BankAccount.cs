namespace ENSE707_Week1_Lab;

public class BankAccount
{
    private const decimal TransactionFeeRate = 0.02m;

    public string AccountHolder { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountHolder, decimal openingBalance)
    {
        if (string.IsNullOrWhiteSpace(accountHolder))
        {
            throw new ArgumentException("Account holder name cannot be empty.", nameof(accountHolder));
        }

        if (openingBalance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(openingBalance), "Opening balance cannot be negative.");
        }

        AccountHolder = accountHolder;
        Balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        ValidatePositiveAmount(amount, nameof(amount), "Deposit amount must be greater than zero.");
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        ValidatePositiveAmount(amount, nameof(amount), "Withdrawal amount must be greater than zero.");

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds for this withdrawal.");
        }

        Balance -= amount;
        return true;
    }

    public decimal CalculateTransactionFee(decimal amount)
    {
        ValidateNonNegativeAmount(amount, nameof(amount), "Transaction amount cannot be negative.");
        return amount * TransactionFeeRate;
    }

    private static void ValidatePositiveAmount(decimal amount, string paramName, string message)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }
    }

    private static void ValidateNonNegativeAmount(decimal amount, string paramName, string message)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }
    }
}
