using System;

namespace LabOP_2Sem
{
    public class Manager : Worker
    {
        public Manager(string lastName, string firstName, Company company = null) : base(lastName, firstName, company)
        {
            
        }
        public override void Work()
        {
            Console.Write("I`m managing");
        }
    }
}