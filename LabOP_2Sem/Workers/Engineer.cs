using System;

namespace LabOP_2Sem
{
    public class Engineer : Worker
    {
        public Engineer(string lastName, string firstName, Company company = null, uint salary = 0) : base(lastName, firstName, company, salary)
        {
            
        }
        public override void Work()
        {
            Console.Write("I`m engineering");
        }

        public Invention Construct(string name)
        {
            return new Invention("randomInvent", name);
        }
    }
}