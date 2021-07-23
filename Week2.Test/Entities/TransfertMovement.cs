using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public class TransfertMovement : Movement
    {
        public string OriginBank { get; set; }
        public string DestinationBank { get; set; }
        public TransfertMovement(double import, DateTime movementDate, string originBank, string destinationBank)
            : base(import, movementDate)
        {
            OriginBank = originBank;
            DestinationBank = destinationBank;
        }
    }
}
