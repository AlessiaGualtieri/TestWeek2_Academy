using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class Helper
    {
        public static int ReadInt(int min, int max)
        {
            int choice;
            bool success;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out choice);
                if (!success || choice < min || choice > max)
                    Console.Write("Input not valid. Try again: ");
            } while (!success || choice < min || choice > max);
            return choice;
        }
        public static double ReadDouble(double min, double max)
        {
            double value;
            bool success;
            do
            {
                success = Double.TryParse(Console.ReadLine(), out value);
                if (!success || value < min || value > max)
                    Console.Write("Input not valid. Try again: ");
            } while (!success || value < min || value > max);
            return value;
        }

        internal static DateTime ReadDateTime(DateTime min, DateTime max)
        {
            DateTime value;
            bool success;
            do
            {
                success = DateTime.TryParse(Console.ReadLine(), out value);
                if (!success || value < min || value > max)
                    Console.Write("Input not valid. Try again: ");
            } while (!success || value < min || value > max);
            return value;
        }
    }
}
