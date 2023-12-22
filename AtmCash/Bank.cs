// See https://aka.ms/new-console-template for more information

public class Bank
{
    public int BankId { get; set; }
    private readonly List<Customer> _accounts;

    public Bank()
    {
        BankId = 1232;
        _accounts =
        [
            new Customer(1, 123456789012, 1234, 5000),
            new Customer(2, 112233445566, 1114, 10000),
            new Customer(3, 332244557766, 1334, 15000),
        ];
    }

    public bool ValidateAccount(long accountNumber, int pin)
    {
        return _accounts.Any(a => a.AccountNo.Equals(accountNumber) && a.Pin.Equals(pin));
    }

    public bool WithdrawCash(long accountNumber, int amount)
    {
        if (!AccountExists(accountNumber))
        {
            Console.WriteLine("Account not found.");
            return false;
        }

        Customer accountDetails = GetCustomer(accountNumber);
        if (accountDetails.Balance < amount)
        {
            Console.WriteLine("Insufficient balance in the account.");
            return false;
        }

        accountDetails.WithdrawCash(amount);
        Console.WriteLine($"Cash withdrawal completed. Remaining balance: {accountDetails.Balance}");
        return true;
    }

    private Customer GetCustomer(long accountNumber)
    {
        return _accounts.Single(a => a.AccountNo.Equals(accountNumber));
    }

    private bool AccountExists(long accountNumber)
    {
        return _accounts.Any(a => a.AccountNo.Equals(accountNumber));
    }
}