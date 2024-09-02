namespace Bank_Clone
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        private List<string> Statement;

        public BankAccount(decimal actualBalance)
        {
            Balance = actualBalance;
            Statement = new List<string> {$"Account created with an initial balance of: {actualBalance:C} "};
        }

        public bool MakeDeposit(decimal value)
        {
            Balance += value;
            Statement.Add($"Make Deposit: {value:C} | Actual balance: {Balance:C}");
            return true;
        }

        public bool ToWithdraw(decimal value)
        {
            if (value <= Balance)
            {
                Balance -= value;
                Statement.Add($"To Withdraw: {value:C} | Actual balance: {Balance:C}");
                return true;
            }
            else
            {
                Statement.Add($"Insufficient balance | Actual balance: {Balance:C}");
                return false;
            }
        }

        public string ShowStatement()
        {
            return string.Join("\n", Statement);
        }
    }
}
