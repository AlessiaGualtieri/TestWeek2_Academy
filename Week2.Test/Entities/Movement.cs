using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public class Movement : IMovement
    {
        public double Import { get; set; }
        public DateTime MovementDate { get; set; }
        public MovementType Type { get; set; }


        public Movement(double import, DateTime movementDate)
        {
            Import = import;
            MovementDate = movementDate;
        }

        public override string ToString()
        {
            string sign = "";
            if (Type == MovementType.Withdrawal)
                sign = "(-)";
            else if (Type == MovementType.Deposit)
                sign = "(+)";
            return $"{MovementDate.ToShortDateString()}: {sign} {Import} euro";
        }
    }
}
