// See https://aka.ms/new-console-template for more information

public class Customer
{
    public Customer(int id, long accountNo, int pin, decimal balance)
    {
        Id = id;
        AccountNo = accountNo;
        Pin = pin;
        Balance = balance;
    }

    public int Id { get; private set; }
    public long AccountNo { get; private set; } = default!;
    public int Pin { get; private set; }
    public decimal Balance { get; private set; }

    public Customer WithdrawCash(decimal amount)
    {
        Balance -= amount;
        return this;
    }
}
