using System;
using Week2.Test.Entities;

namespace Week2.Test
{
    class Program
    {
        public static Account account { get; set; }
        static void Main(string[] args)
        {
            CreateAccount();
            while (Menu()) ;
        }

        public static void CreateAccount()
        {
            string iban, bankName;
            Console.Write("----- WELCOME -----\n" +
                "To create a new Account, insert IBAN: ");
            iban = Console.ReadLine();
            Console.Write("Great! Now insert your Bank's name: ");
            bankName = Console.ReadLine();

            account = new Account(iban, bankName);
            Console.WriteLine("--> Account successfully created!");
        }

        public static bool Menu()
        {
            int choice;
            Console.Write("\n----- MENU -----\n" +
                "1 - Insert movement to account\n" +
                "2 - Show account info\n" +
                "3 - Exit\n\t> ");
            choice = Helper.ReadInt(1, 3);

            switch(choice)
            {
                case 1:
                    InsertMovement();
                    break;
                case 2:
                    account.Statement();
                    break;
                case 3:
                    return false;
            }
            return true;
        }

        public static void InsertMovement()
        {
            int choice;
            IMovement movement;
            Console.Write("\nChoose what kind of movement you want to insert:\n" +
                "1 - Cash movement\n" +
                "2 - Transfert movement\n" +
                "3 - Credit card Movement\n" +
                "\t> ");
            choice = Helper.ReadInt(1, 3);

            Console.Write("What's the movement import?\n\t> ");
            double import = Helper.ReadDouble(0.01,double.MaxValue);
            Console.Write("What's the movement date?\n\t> ");
            DateTime movementDate = Helper.ReadDateTime(new DateTime(2000,01,01), DateTime.Today);
            movement = new Movement(import, movementDate);

            movement = (choice == 1) ? ReadCashMovement(movement) :
                (choice == 2) ? ReadTransfertMovement(movement) : 
                ReadCreditCardMovement(movement);
            

            Console.Write("Is this a deposit or a withdrawal?\n" +
                "1 - Deposit\n" +
                "2 - Withdrawal\n\t> ");
            choice = Helper.ReadInt(1, 2);

            account = (choice == 1) ? account + movement : account - movement;
            Console.WriteLine("--> Movement successfully added!");

        }

        public static CashMovement ReadCashMovement(IMovement movement)
        {
            Console.Write("What's the executor?\n\t> ");
            string executor = Console.ReadLine();
            return new CashMovement(movement.Import, movement.MovementDate, executor);
        }

        public static TransfertMovement ReadTransfertMovement(IMovement movement)
        {
            Console.Write("What's the origin bank?\n\t> ");
            string originBank = Console.ReadLine();
            Console.Write("What's the destination bank?\n\t> ");
            string destinationBank = Console.ReadLine();
            return new TransfertMovement(movement.Import, movement.MovementDate, originBank, destinationBank);

        }

        public static CreditCardMovement ReadCreditCardMovement(IMovement movement)
        {
            Console.Write("What's the credit card type?\n" +
                "1 - Amex\n" +
                "2 - Visa\n" +
                "3 - Mastercard\n" +
                "4 - Other\n\t> ");
            int choice = Helper.ReadInt(1, 4);
            CreditCardType creditCardType = (CreditCardType)Enum.ToObject(typeof(CreditCardType), choice);

            Console.Write("What's the iban?\n\t> ");
            string iban = Console.ReadLine();
            return new CreditCardMovement(movement.Import, movement.MovementDate, iban, creditCardType);

        }
    }
}
