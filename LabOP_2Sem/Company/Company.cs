#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LabOP_2Sem
{
    public class Company
    {
        private string Name { get; }

        private List<Worker> Staff { get; } = new ();

        private static List<Company?> RegisteredCompanies = new();

        private Manager _ceo;
        private Manager Ceo
        {
            get => _ceo;
            set
            {
                _ceo = value;
                Staff.Add(_ceo);
            }
        }

        public static Company? Register(string name, Worker? ceo = null)
        {
            if (Contains(RegisteredCompanies, name, ceo))
            {
                Console.WriteLine("This company is already registered");
                return null;
            }
            var company = new Company(name, ceo);
            RegisteredCompanies.Add(company);
            return company;
        }

        private Company(string name, Worker worker)
        {
            Name = name;
            Ceo = worker.PromoteToManager(this);
            Console.WriteLine($"{Name} has successfully registered");
        }
        
        public bool FireWorker(Worker worker)
        {
            if (!Staff.Contains(worker)) return false;
            Staff.Remove(worker);
            Ceo.Fire(worker);
            return true;

        }

        public void HireWorker(Worker worker)
        {
            if (Staff.Contains(worker))
            {
                throw new Exception("This worker is already in Company");
            }
            Staff.Add(worker);
            worker.ApllyToAJob(this);
        }
        
        public void HireWorkers(Collection<Worker> workers)
        {
            foreach (var worker in workers)
            {
                if (Staff.Contains(worker))
                {
                    throw new Exception($"{worker} is already in Company");
                }

                Staff.Add(worker);
                worker.ApllyToAJob(this);
            }
            
        }

        public override string ToString()
        {
            return $"Name:{Name}, CEO: {Ceo}";
        }

        private static bool Contains(List<Company?> regCompanies, string name, Worker? ceo)
        {
            return regCompanies.Any(company => company.Name == name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Ceo.GetHashCode() + Staff.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            return obj != null && GetHashCode() == obj.GetHashCode();
        }

        public void SetManager(Manager ceo)
        {
            Ceo = ceo;
            ceo.ApllyToAJob(this);
        }
    }
}