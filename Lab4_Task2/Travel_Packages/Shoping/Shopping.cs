using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    public class Shopping : Travel_Package
    {

        private List<string> ShopNames = new(){"Adidas", "Calvin Klein", "Cmyk", "Billa"};
        public Shopping(uint days, uint price, Transport transport, Country country, Nutrition_Types type) : base(
            days, price, country, type)
        {
            Days = days;
            Price = price;
            _transport = transport;
            TourList.Add(country);
            Diet = type;
        }

        public void GoShopping()
        {
            foreach (var name in ShopNames)
            {
                Console.Write("I`m shopping at" + name);
            }
        }
    }
}