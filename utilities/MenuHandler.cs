namespace banking_app.utilities
{
    public class MenuHandler
    {
        private Client client;

        public MenuHandler(Client client)
        {
            this.client = client;
        }

        public bool HandleMenu()
        {
            DisplayOptions();
            string userChoice = GetUserResponse();
            if (userChoice == "X")
            {
                return false;
            }
            ExecuteUserChoice(userChoice);
            return true;
        }

        private void DisplayOptions()
        {
            Console.WriteLine(@"Veuillez sélectionner une option ci-dessous :
                                        [I] Voir les informations sur le titulaire du compte
                                        [CS] Compte courant - Consulter le solde
                                        [CD] Compte courant - Déposer des fonds
                                        [CR] Compte courant - Retirer des fonds
                                        [ES] Compte épargne - Consulter le solde
                                        [ED] Compte épargne - Déposer des fonds
                                        [ER] Compte épargne - Retirer des fonds
                                        [X] Quitter");
        }

        private string GetUserResponse()
        {
            // Define the valid responses
            HashSet<string> validResponses = new HashSet<string> { "I", "CS", "CD", "CR", "ES", "ED", "ER", "X" };

            while (true) 
            {
                string userResponse = Console.ReadLine().ToUpper();

                if (validResponses.Contains(userResponse)) 
                {
                    return userResponse;
                }
                else 
                {
                    Console.WriteLine("Invalid input. Please enter one of the following options: I, CS, CD, CR, ES, ED, ER, X");
                }
            }
        }

        private void ExecuteUserChoice(string userResponse)
        {
            bool successfulOperation;  // Add this line

            switch(userResponse)
            {
                case "I":
                    Console.WriteLine($"Client name: {client.Name}");
                    Console.WriteLine($"Compte courant number: {client.CompteCourant.AccountNumber}");
                    Console.WriteLine($"Compte épargne number: {client.CompteEpargne.AccountNumber}");
                    break;

                case "CS":
                    Console.WriteLine($"Compte courant balance: {client.CompteCourant.Solde}");
                    break;

                case "CD":
                    Console.WriteLine("Entrez le montant du dépôt:");
                    float amountToDepositToCompteCourant = float.Parse(Console.ReadLine());
                    client.CompteCourant.Deposit(amountToDepositToCompteCourant);
                    Console.WriteLine($"Vous avez déposé : {amountToDepositToCompteCourant}€");
                    break;

                case "CR":
                    Console.WriteLine("Entrez le montant du retrait:");
                    float amountToWithdrawFromCompteCourant = float.Parse(Console.ReadLine());
                    successfulOperation = client.CompteCourant.Withdraw(amountToWithdrawFromCompteCourant);
                    if (successfulOperation)
                    {
                        Console.WriteLine($"Vous avez retiré : {amountToWithdrawFromCompteCourant}€");
                    }
                    break;

                case "ES":
                    Console.WriteLine($"Compte épargne balance: {client.CompteEpargne.Solde}");
                    break;

                case "ED":
                    Console.WriteLine("Entrez le montant du dépôt:");
                    float amountToDepositToCompteEpargne = float.Parse(Console.ReadLine());
                    client.CompteEpargne.Deposit(amountToDepositToCompteEpargne);
                    Console.WriteLine($"Vous avez déposé : {amountToDepositToCompteEpargne}€");
                    break;

                case "ER":
                    Console.WriteLine("Entrez le montant du retrait:");
                    float amountToWithdrawFromCompteEpargne = float.Parse(Console.ReadLine());
                    successfulOperation = client.CompteEpargne.Withdraw(amountToWithdrawFromCompteEpargne);
                    if (successfulOperation)
                    {
                        Console.WriteLine($"Vous avez retiré : {amountToWithdrawFromCompteEpargne}€");
                    }
                    break;
            }
            // After each case, add code to pause the program until the user presses Enter
            Console.WriteLine("Press Enter to display the menu.");
            Console.ReadLine();
        }

    }
}