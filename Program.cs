using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;

namespace PasswordGenerator
{
    class Program
    {
        private static bool DataEntries(string type)
        {
            int enter;

            Console.Write($"Digit if your password contains {type} (0 - NOT / 1 - YES): ");            

            // Explicação: Se NÃO for um número repete o loop e se for um número diferente de 0 e 1 repete também.
            while (!int.TryParse(Console.ReadLine(), out enter) || (enter != 0 && enter != 1))
            {
                Console.Write("Invalid! Digit 0 or 1: ");
            }

            bool choose = (enter == 1);
            return choose;
        }

        static void Main(string[] args)
        {

            bool chooseNumbers = DataEntries("[Numbers]");
            bool chooseSpecialCharacters = DataEntries("[Special Characters]");
            bool chooseUppercaseLetters = DataEntries("[Uppercase Letters]");
            
            Console.Write($"Enter the length of your password (8 - 128): ");
            int passwordLength;
            while (!int.TryParse(Console.ReadLine(), out passwordLength) || (passwordLength <= 8 && passwordLength >= 128))
            {
                Console.Write("Erro! Digit a valid value: ");
            }

        }
    }
}