using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabOP_2Sem
{
    public class MainC
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Company nestle = Company.Register("Nestle");
            Manager billGates = new Manager("Gates", "Bill", nestle, 2000);
            Worker intern = new Engineer("Lawson", "Eugene", nestle, 1000);
            Console.Write(nestle);
        }
        
    }
}