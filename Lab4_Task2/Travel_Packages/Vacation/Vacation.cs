using System;

namespace ConsoleApplication1.Vacation
{
    public class Vacation : Travel_Package
    {
        public Vacation(uint days, uint price, Transport transport, Country country, Nutrition_Types type) : base
            (days, price, country, type)
        {
            Days = days;
            Price = price;
            _transport = transport;
            TourList.Add(country);
            Diet = type;
        }

        public void Relax()
        {
            Console.WriteLine("You're being relaxed");
        }
    }
}