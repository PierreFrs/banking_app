namespace banking_app
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public float Solde { get; private set; }

        public BankAccount(string accountNumber, float solde)
        {
            this.AccountNumber = accountNumber;
            this.Solde = solde;
        }
        public void DisplayAccount()
        {
            Console.WriteLine(Solde);
        }
        public void Deposit(float amount) 
        {
           this.Solde += amount;
        }
        public bool Withdraw(float amount)
        {
            if (amount <= Solde) 
            {
                this.Solde -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Vous ne disposez pas des fonds nécessaires afin d'effectuer cette opération, veuillez contacter votre banque.");
                return false;
            }
        }

    }
}