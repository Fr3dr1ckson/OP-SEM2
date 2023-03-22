using System;
using System.Collections.Generic;

namespace LabOP_2Sem
{
    public class Company
    {
        private string Name { get; set; }
        
        private List<Worker> Staff { get; set; }
        
        private Manager Ceo { get; set; }

        public Company(string name, Manager ceo)
        {
            Name = name;
            Ceo = ceo;
        }

        public void HireWorker(Worker worker)
        {
            if (Staff.Contains(worker))
            {
                throw new Exception("This worker is already in Company");
            }
            Staff.Add(worker);
        }
    }
}