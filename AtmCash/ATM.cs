// See https://aka.ms/new-console-template for more information
public class ATM
{
    public int AtmId { get; set; }

    private readonly List<Bank> _banks = [];
    private readonly Bank _selectedBank;
    private const int maxNotes = 250;
    private readonly Dictionary<int, int> _denominations = [];

    public ATM(Bank bank)
    {
        _denominations.Add(100, maxNotes);
        _denominations.Add(200, maxNotes);
        _denominations.Add(500, maxNotes);
        _banks.Add(bank);
        _selectedBank = bank;
    }

    public ATM AddBank(Bank bank)
    {
        if (!_banks.Any(a => a.BankId == bank.BankId))
        {
            _banks.Add(bank);
        }

        return this;
    }

    public void Initialize()
    {
        // Initialize the ATM and Bank here
    }

    public void Start()
    {
        long accountNumber;
        int pin = 0;

        do
        {
            Console.WriteLine("Enter account number:");
            if (!long.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.WriteLine("Enter a valid account number:");
                continue;
            }

            Console.WriteLine("Enter PIN:");
            if (!int.TryParse(Console.ReadLine(), out pin))
            {
                Console.WriteLine("Enter a valid PIN:");
                continue;
            }

        } while (!_selectedBank.ValidateAccount(accountNumber, pin));

        Console.WriteLine("Login successful.");

        Console.WriteLine("Enter the amount to withdraw:");
        int amount;
        int.TryParse(Console.ReadLine(), out amount);

        if (!IsCashAvailable(accountNumber, amount))
        {
            Console.WriteLine("ATM does not have sufficient cash to fulfill the amount.");
            return;
        }

        _selectedBank.WithdrawCash(accountNumber, amount);
    }

    private bool IsCashAvailable(long accountNumber, int amount)
    {
        // Assuming ATM has denominations of 100, 200, 500
        int remainingAmount = amount;
        int[] denominations = [500, 200, 100];

        foreach (var denomination in denominations)
        {
            int notesRequired = remainingAmount / denomination;
            var count = _denominations[denomination];

            if (notesRequired > 0 && count >= notesRequired)
            {
                remainingAmount -= notesRequired * denomination;
                _denominations[denomination] = count - notesRequired;
            }
        }
        return remainingAmount == 0;
    }
}
