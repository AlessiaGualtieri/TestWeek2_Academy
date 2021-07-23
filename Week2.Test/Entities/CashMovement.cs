using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test.Entities
{
    public class CashMovement : Movement
    {
        public string Executor { get; set; }

        public CashMovement(double import, DateTime movementDate, string executor) : base(import,movementDate)
        {
            Executor = executor;
        }
    }
}
