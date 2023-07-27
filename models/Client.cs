namespace banking_app
{
    public class Client
    {
        public string Name { get; set; }
        public BankAccount CompteCourant { get; set; }
        public BankAccount CompteEpargne { get; set; }

        public Client(string name, BankAccount compteCourant, BankAccount compteEpargne)
        {
            Name = name;
            CompteCourant = compteCourant;
            CompteEpargne = compteEpargne;
        }
    }

}