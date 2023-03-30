using System;

namespace LabOP_2Sem
{
    public class Intern : Worker
    {
        public Intern(string lastName, string firstName, Company company = null) : base(lastName, firstName, company)
        {
            
        }
        public override void Work()
        {
            Console.Write("I`m managing");
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} passes internship in {WorkPlace}";
        }
    }
}