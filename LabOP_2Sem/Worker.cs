using System;

namespace LabOP_2Sem
{
    public class Worker
    {
        protected Worker(string lastName, string firstName, Company company = null)
        {
            LastName = lastName;
            FirstName = firstName;
            WorkPlace = company;
        }

        private string FirstName { get; }
        
        private string LastName { get; }
        
        private Company WorkPlace { get; set; }

        public virtual void Work()
        {
            Console.Write("I`m working");
        }
    }
}