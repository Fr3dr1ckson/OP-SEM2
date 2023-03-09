using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
        }

        private double Imaginary
        {
            get;
        }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
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

        public static Complex[] SquareRoot(Complex num)
        {
            var real = num.Real;
            var imag = num.Imaginary;
            var firstRoot = Math.Sqrt((real + Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2))) / 2);
            var secondRoot = Math.Sqrt((-real + Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2))) / 2);
            return new []{ new Complex(firstRoot, secondRoot), new Complex(-firstRoot,-secondRoot) };
        }

        private static Complex Power(Complex num, double power)
        {
            var real = num.Real;
            var imag = num.Imaginary;
            var modulus = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            var argument = 1 / Math.Tan(imag / real / PI);
            var realDeMoivre = Math.Pow(modulus, power) * Math.Cos(power * argument);
            var imaginaryDeMoivre = Math.Pow(modulus, power) * Math.Sin(power * argument);
            return new Complex(realDeMoivre, imaginaryDeMoivre);
        }

        private static string toPi(double num)
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
        
        public async void ToJson(string path)
        {
            var complex = new Dictionary<string, double>
            {
                { "real", Real },
                { "imaginary", Imaginary }
            };
            using FileStream fs = new FileStream(path,FileMode.Create);
            await JsonSerializer.SerializeAsync(fs, complex, new JsonSerializerOptions{WriteIndented = true, AllowTrailingCommas = true});
        } 

        public string ToString(OutputForm form)
        {
            var argument = toPi(1 / Math.Tan(Imaginary / Real));
            switch (form)
            {
                case OutputForm.Algebraic:
                    return $"{Real} + {Imaginary}i";
                case OutputForm.Exponential:
                    return $"{Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2))}e^i{argument}";
                case OutputForm.Polar:
                    return $"cos{argument} + isin{argument}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(form), form, null);
            }
        }
    }
}