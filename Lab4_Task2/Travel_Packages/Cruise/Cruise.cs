using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Cruise: Travel_Package
    {
        public Cruise(uint days, uint price, List<Country> countries, Nutrition_Types type) : base
            (days, price, countries, type)
        {
            Days = days;
            Price = price;
            _transport = Transport.Motorship;
            TourList = countries;
            Diet = type;
        }

        public void Swim()
        {
            foreach (var country in TourList)
            {
                Console.Write("I'm at" + country.Name);
            }
        }
    }
}