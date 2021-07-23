using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public enum CreditCardType
    {
        AMEX = 1,
        VISA,
        MASTERCARD,
        OTHER
    }
    public class CreditCardMovement : Movement
    {
        public string Iban { get; set; }
        public CreditCardType Type { get; set; }
        public CreditCardMovement(double import, DateTime movementDate, string iban, CreditCardType type)
            : base(import, movementDate)
        {
            Iban = iban;
            Type = type;
        }
    }
}
