namespace Bank_Clone
{
    public class BankApp
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User("Gabriel", "123456", "senha123", 1000),
                new User("Arthur", "456123", "senha1234", 1000),
                new User("Eduardo", "654321", "senha12345", 1000)
            };

            Console.WriteLine("Welcome to the FakeBank!");

            Console.WriteLine();

            Console.Write("Please enter your account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Now, please enter your password: ");
            string password = Console.ReadLine();

            Console.WriteLine();

            var user = users.Find(u => u.Authentication(accountNumber, password));

            if (user != null)
            {
                Console.WriteLine($"Welcome {user.Name}!");
                Console.WriteLine();

                bool execute = true;
                while (execute)
                {
                    Console.WriteLine("How can i help you today?");

                    Console.WriteLine();

                    Console.Write("1 - Account balance    /    ");
                    Console.Write("2 - Statement    /    ");
                    Console.Write("3 - Transfers    /    ");
                    Console.WriteLine("4 - Exit");

                    Console.WriteLine();

                    Console.Write("(Choose a option): ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine();
                            Console.WriteLine($"Your actual balance is: {user.Account.Balance}");
                            Console.WriteLine();
                            break;
                        case "2":
                            Console.WriteLine();
                            Console.WriteLine("Statement");
                            Console.WriteLine(user.Account.ShowStatement());
                            Console.WriteLine();
                            break;
                        case "3":
                            Console.WriteLine();
                            Console.Write("Enter the transfer amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                            {
                                if (user.Account.ToWithdraw(transferAmount))
                                {
                                    Console.WriteLine($"Transfer completed successfully! | Actual balance: {user.Account.Balance:C}");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"Insufficient balance | Actual balance:{user.Account.Balance:C} ");
                                    Console.WriteLine();
                                }

                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid amount: ");
                            }
                            break;
                        case "4":
                            Console.WriteLine();
                            Console.WriteLine("Bye bye!");
                            execute = false;
                            break;
                        default:
                            Console.WriteLine("Please, enter a valid option: ");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid account number or password");
            }
        }
    }
}