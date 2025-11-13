using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace PasswordGenerator
{
    public static class PasswordSets
    {
        public static readonly string Number = "0123456789";
        public static readonly string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string Special = "!@#$%^?*()[]{}|;:~";
    }

    
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

            StringBuilder pool = new StringBuilder();
            pool.Append(PasswordSets.Lowercase);
            if (chooseNumbers) pool.Append(PasswordSets.Number);
            if (chooseSpecialCharacters) pool.Append(PasswordSets.Special);
            if (chooseUppercaseLetters) pool.Append(PasswordSets.Uppercase);

            StringBuilder password = new StringBuilder(); ;
            for (int i = 0; i <= passwordLength; i++)
            {
                int index = RandomNumberGenerator.GetInt32(pool.Length);
                password.Append(pool[index]);
            }

            string finalPassword = password.ToString();
            Console.WriteLine($"\nGenerated password: {finalPassword}");

        }
    }
}