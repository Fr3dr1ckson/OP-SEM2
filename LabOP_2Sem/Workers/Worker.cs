using System;

namespace LabOP_2Sem
{
    public class Worker
    {
        protected Worker(string lastName, string firstName, Company company = null, uint salary = 0)
        {
            LastName = lastName;
            FirstName = firstName;
            WorkPlace = company;
            Salary = salary;
        }

        internal uint Salary { get; set; }
        
        internal string FirstName { get; }
        
        internal string LastName { get; }
        
        internal Company WorkPlace { get; set; }

        public virtual void Work()
        {
            Console.Write("I`m working");
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode() && obj.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public bool ApllyToAJob(Company company, uint salary = 0)
        {
            WorkPlace = company;
            Salary = salary;
            return true;
        }

        public void LeaveJob()
        {
            WorkPlace = null;
            Salary = 0;
        }
        public void Raise(uint money)
        {
            Salary += money;
        }

        public Manager PromoteToManager(Company company)
        {
            return new Manager(LastName, FirstName, company, Salary);
        }

        public Engineer PromoteToEngineer(Company company, uint salary)
        {
            return new Engineer(LastName, FirstName, company, salary);
        }
    }
}