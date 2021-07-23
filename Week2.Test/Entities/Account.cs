using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public class Account
    {
        
        #region Fields and Properties

        private DateTime _lastOperationDate;
        private IList<IMovement> _movements = new List<IMovement>();
        public string Iban { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }
        public DateTime LastOperationDate { get {return _lastOperationDate; } }
        public IList<IMovement> Movements { get {return _movements; } }
        #endregion

        #region Constructors
        public Account(string iban, string bankName)
        {
            Iban = iban;
            BankName = bankName;
        }
        #endregion

        #region Operators overload
        public static Account operator +(Account account, IMovement movement)
        {
            account._movements.Add(movement);
            account.Balance += movement.Import;
            account._lastOperationDate = movement.MovementDate;
            movement.Type = MovementType.Deposit;
            return account;
        }
        public static Account operator -(Account account, IMovement movement)
        {
            account._movements.Add(movement);
            account.Balance -= movement.Import;
            account._lastOperationDate = movement.MovementDate;
            movement.Type = MovementType.Withdrawal;
            return account;
        }
        #endregion

        #region Methods

        public void Statement()
        {
            string lastOperationDate = "- no operations -";
            if (Movements.Count != 0)
                lastOperationDate = LastOperationDate.ToShortDateString();
            Console.WriteLine($"\n--- Bank Account Info ---\n" +
                $"IBAN: {Iban}\n" +
                $"Bank name: {BankName}\n" +
                $"Balance: {Balance} euro\n" +
                $"Last operation date: {lastOperationDate}\n" +
                $"Movements:");
            if (Movements.Count == 0)
            {
                Console.WriteLine("\tThere are no movements");
                return;
            }
            IList<IMovement> sortedMovements = Movements.OrderByDescending(m => m.MovementDate).ToList();
            foreach (var m in sortedMovements)
            {
                Console.WriteLine($"\t> {m}");
            }
        }

        public override string ToString()
        {
            return $"IBAN: {Iban}\n" +
                $"Bank name: {BankName}\n" +
                $"Balance: {Balance} euro\n" +
                $"Last operation date: {LastOperationDate}\n";
        }

        #endregion

        
    }
}
