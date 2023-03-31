using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Travel_Package
    {
        internal uint Price { get; set; }
        
        internal uint Days { get; set; }
        
        internal Transport _transport { get; set; }

        internal List<Country> TourList = new();

        public enum Transport
        {
            Plane,
            Train,
            Bus,
            Motorship
        }

        public class Country
        {
            public string Name { get; }
            
            public uint Population { get; set; }

            public Country(string name, uint population)
            {
                Name = name;
                Population = population;
            }
        }

        internal Nutrition_Types Diet = Nutrition_Types.None;

        public enum Nutrition_Types
        {
            None,
            AllInclusive,
            FullBoard,
            Menu
        }

        internal readonly List<Human> SignedPeople = new();

        internal uint NumberOfPeople => (uint)SignedPeople.Count;

        public Travel_Package(uint days, uint price, Country country, Nutrition_Types type)
        {
            Days = days;
            Price = price;
            TourList.Add(country);
            Diet = type;
        }
        public Travel_Package(uint days, uint price, List<Country> countries, Nutrition_Types type)
        {
            Days = days;
            Price = price;
            TourList = countries;
            Diet = type;
        }
        public bool Sign(Human human)
        {
            if (!SignedPeople.Contains(human)) 
            {
                Console.Write("This person is already signed");
                return false;
            }
            SignedPeople.Add(human);
            Console.Write("Signed successfully");
            return true;
        }
        public void Sign(List<Human> people)
        {
            foreach (var human in people)
            {
                Sign(human);
            }
        }
    }
}