using System;
using System.IO;

namespace ConsoleApplication1
{
    public class Human
    {
        private string FirstName;

        private string LastName;

        private uint Age;

        private DateTime Birthday;

        public enum Sex
        {
            Male,
            Female,
            Other,
            None
        }

        private Sex sex;

        public Human(string firstName, string lastName, Sex sex, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            this.sex = sex;
            Birthday = birthday;
            Age = (uint)(DateTime.Now.Year - birthday.Year);
        }
    }
}