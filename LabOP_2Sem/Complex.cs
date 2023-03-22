using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static System.Text.Json.JsonSerializer;

namespace LabOP_2Sem
{
    public class Complex
    {
        private const double PI = Math.PI;
        public enum OutputForm 
        {
            Algebraic,
            Exponential,
            Polar,
        }

        private double Real
        {
            get;
            set;
        }

        private double Imaginary
        {
            get;
            set;
        }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        ~Complex(){
            Console.Write("Hello World");
        }
        private static Complex Add(Complex num1, Complex num2)
        {
            double realSum = num1.Real + num2.Real;
            double imaginarySum = num1.Imaginary + num2.Imaginary;
            return new Complex(realSum, imaginarySum);
        }

        private static Complex Subtract(Complex num1, Complex num2)
        {
            double realSubs = num1.Real - num2.Real;
            double imaginarySubs = num1.Imaginary - num2.Imaginary;
            return new Complex(realSubs, imaginarySubs);
        }

        private static Complex Divide(Complex num1, Complex num2)
        {
            var real1 = num1.Real;
            var imag1 = num1.Imaginary;
            var real2 = num2.Real;
            var imag2 = num2.Imaginary;
            double real = (real1 * real2 + imag1 * imag2) / (Math.Pow(real2, 2) + Math.Pow(imag2, 2));
            double imaginary = (imag1 * real2 - real1 * imag2) / (Math.Pow(real2, 2) + Math.Pow(imag2, 2));
            return new Complex(real, imaginary);
        }

        private static Complex Multiply(Complex num1, Complex num2)
        {
            var real1 = num1.Real;
            var imag1 = num1.Imaginary;
            var real2 = num2.Real;
            var imag2 = num2.Imaginary;
            double real = real1 * real2 - imag1 - imag2;
            double imaginary = real1 * imag2 - imag1 * real2;
            return new Complex(real, imaginary);
        }

        public Complex NRoot(double power)
        {
            var modulus = Math.Pow(Real*Real + Imaginary*Imaginary, power%2 == 0 ? 1/power: 1/power*2);
            var argument = Math.Atan2(Imaginary,Real);
            var real = modulus * Math.Cos(argument);
            var imag = modulus * Math.Sin(argument);
            return new Complex(real,imag);
        }

        ///<summary>
        /// Method, that puts a complex number in a power, with a DeMoivre method
        ///<see cref="Complex">Complex</see>
        ///</summary>
        /// <param name="num">A complex number we put in the power</param>
        /// <param name="power">A double value that is a power of our complex number</param>
        /// <returns>A complex number in power of n</returns>
        private static Complex Power(Complex num, double power)
        {
            var real = num.Real;
            var imag = num.Imaginary;
            var modulus = Math.Sqrt(real*real + imag*imag);
            var argument = Math.Atan2(imag,real);
            var realDeMoivre = Math.Pow(modulus, power) * Math.Cos(power * argument);
            var imaginaryDeMoivre = Math.Pow(modulus, power) * Math.Sin(power * argument);
            return new Complex(realDeMoivre, imaginaryDeMoivre);
        }

        private static string ToPi(double num)
        {
            return $"{Math.Round(num/PI)}π";
        }
        private static bool Equals(Complex num1, Complex num2)
        {
            return num1.Real.Equals(num2.Real) && num1.Imaginary.Equals(num2.Imaginary);
        }

        public static Complex operator +(Complex a, Complex b) => Add(a, b);
        
        public static Complex operator -(Complex a, Complex b) => Subtract(a, b);
        
        public static Complex operator *(Complex a, Complex b) => Multiply(a, b);
        
        public static Complex operator /(Complex a, Complex b) => Divide(a, b);
        
        public static Complex operator ^(Complex a, double b) => Power(a, b);
        
        public static bool operator ==(Complex a, Complex b) => Equals(a, b);

        public static bool operator !=(Complex a, Complex b) => !(a == b);
        
        public override string ToString() => $"{Real} + {Imaginary}i";
        
        public void ToJson(string path)
        {
            var complex = new Dictionary<string, double>
            {
                { "Real", Real },
                { "Imaginary", Imaginary }
            };
            using FileStream fs = new FileStream(path,FileMode.Create);
            Serialize(fs, complex, new JsonSerializerOptions{WriteIndented = true, AllowTrailingCommas = true});
        }
        
        public static Complex FromJson(string path)
        {
            string json = File.ReadAllText(path);
            var deserializedJson = Deserialize<Dictionary<string, double>>(json);
            return new Complex(deserializedJson["Real"], deserializedJson["Imaginary"]);
        }

        public string ToString(OutputForm form)
        {
            var argument = ToPi(1 / Math.Tan(Imaginary / Real));
            return form switch
            {
                OutputForm.Algebraic => $"{Real} + {Imaginary}i",
                OutputForm.Exponential => $"{Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2))}e^i{argument}",
                OutputForm.Polar => $"cos{argument} + isin{argument}",
                _ => throw new ArgumentOutOfRangeException(nameof(form), form, null)
            };
        }
    }
}