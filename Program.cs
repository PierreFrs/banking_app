using banking_app;
using banking_app.utilities;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("John Doe", new BankAccount("12345", 1000), new BankAccount("67890", 2000));
            MenuHandler menu = new MenuHandler(client);

            while (menu.HandleMenu()) {}
        }
    }
}