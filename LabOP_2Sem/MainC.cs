using System;
using System.Text;

namespace LabOP_2Sem
{
    public static class MainC
    {
        private static readonly string path = @"C:\Users\onarg\RiderProjects\OP-SEM2v2\LabOP_2Sem\json\complex.json";

        private static readonly double PI = Math.PI;
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Complex num = new Complex(Math.Cos(PI/2), Math.Sin(PI/2));
            //Console.Write(num);
            num.ToJson(path);
            Console.Write(Complex.FromJson(path));
        }
    }
}