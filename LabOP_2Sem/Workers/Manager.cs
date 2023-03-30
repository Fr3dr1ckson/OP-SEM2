using System;

namespace LabOP_2Sem
{
    public class Manager : Worker
    {
        public Manager(string lastName, string firstName, Company company, uint salary = 0) : base(lastName, firstName, salary: salary)
        {
            company.SetManager(this);
        }
        public override void Work()
        {
            Console.Write("I`m managing");
        }

        public bool Fire(Worker worker)
        {
            return worker.ApllyToAJob(null, 1000);
        }
    }
}