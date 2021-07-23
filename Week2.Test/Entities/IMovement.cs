using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public enum MovementType
    {
        Withdrawal,
        Deposit
    }
    public interface IMovement
    {
        public double Import { get; set; }
        public DateTime MovementDate { get; set; }
        public MovementType Type { get; set; }

    }
}
