using System;
using System.Diagnostics;

namespace DiffieHellman
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter count of side: ");
            if (Int32.TryParse(Console.ReadLine(), out int validNumber))
            {
                ControllerDiffieHelman diffieHelman = new ControllerDiffieHelman();
                diffieHelman.GenerateSecureKeyForNSides(validNumber);
            }
            else
                throw new Exception("Invalid number!!!");
        }
    }
}
