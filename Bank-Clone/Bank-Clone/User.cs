namespace Bank_Clone
{
    public class User
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public BankAccount Account { get; set; }

        public User(string name, string accountNumber, string password, decimal initialBalance) 
        {
            Name = name;
            AccountNumber = accountNumber;
            Password = password;
            Account = new BankAccount(initialBalance);
        }

        public bool Authentication(string accountNumber, string password)
        {
            return AccountNumber == accountNumber && Password == password;
        }

    }
}
