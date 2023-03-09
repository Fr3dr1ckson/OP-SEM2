using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace LabOP_2Sem
{
    public class MainC
    {
        private static readonly string path = @"C:\Users\onarg\RiderProjects\LabOP_2Sem\LabOP_2Sem\json\complex.json";

        private static readonly double PI = Math.PI;
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Complex num = new Complex(Math.Cos(PI/2), Math.Sin(PI/2));
            Console.Write(num);
            num.ToJson(path);
        }
    }
}