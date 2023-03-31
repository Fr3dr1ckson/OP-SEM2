using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Excurtion : Travel_Package
    {

        private List<string> AttractionNames = new() { "Statue", "Museum", "Castle" };
        public Excurtion(uint days, uint price, Transport transport, Country country, Nutrition_Types type) : base
            (days, price, country, type)
        {
            Days = days;
            Price = price;
            _transport = transport;
            TourList.Add(country);
            Diet = type;
        }

        public void VisitSomePlaces()
        {
            foreach (var name in AttractionNames)
            {
                Console.Write("I'm at "+ name);
            }
        }
    }
}