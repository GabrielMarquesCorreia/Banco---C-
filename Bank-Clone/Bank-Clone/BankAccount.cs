using System.Xml.Linq;

namespace Bank_Clone
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }

        private List<string> Statement;

        public BankAccount(decimal actualBalance, string accountNumbers, string name)
        {
            Balance = actualBalance;
            Name = name;
            AccountNumber = accountNumbers;
            Statement = new List<string> {$"Account created with an initial balance of: {actualBalance:C} "};
        }

        public bool MakeDeposit(decimal value)
        {
            Balance += value;
            Statement.Add($"Make Deposit: {value:C} | Your actual balance: {Balance:C}");
            SavingBalance();
            return true;
        }

        public bool ToWithdraw(decimal value,BankAccount destinationAccount, string destinationName)
        {
            if (value <= Balance)
            {
                Balance -= value;
                destinationAccount.Balance += value;
                Statement.Add($"Transfer to {destinationName} of the account {destinationAccount.AccountNumber} of: {value:C} | Your actual balance: {Balance:C}");
                destinationAccount.Statement.Add($"Recived a tranfer of {value:C} from {Name} of the account number {AccountNumber} | Your actual balance: {destinationAccount.Balance:C}");
                SavingBalance();
                destinationAccount.SavingBalance();
                return true;
            }
            else
            {
                Statement.Add($"Insufficient balance | Your actual balance: {Balance:C}");
                return false;
            }
        }

        public string ShowStatement()
        {
            return string.Join("\n", Statement);
        }

        public void SavingBalance()
        {
            File.WriteAllText($"{AccountNumber}_balance.txt", Balance.ToString());
        }

        public void LoadBalance()
        {
            if (File.Exists($"{AccountNumber}_balance.txt"))
            {
                var balanceText = File.ReadAllText($"{AccountNumber}_balance.txt");
                Balance = decimal.Parse(balanceText); 
            }
        }
    }
}
